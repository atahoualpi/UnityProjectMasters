using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hv_FilterBased_AudioLib))]
[RequireComponent(typeof(Rigidbody))]
public class cubeScript_FB : MonoBehaviour {

    public Hv_FilterBased_AudioLib HeavyScript;

    float[] freq_modes = new float[10];
    float[] ampl_modes = new float[10];
    float scaleAvg;

    [HideInInspector]
    public float multiplier = 1f;
    float edge_mult = 1f;

    [HideInInspector]
    public int pulsesPerRotation = 8; //number of irregularities on object
    float pulseIndex; //index of the irregularity

    float distanceTravelled; // distance that has been travelled by object since last pulse/irregularity on object
    //[HideInInspector]
    public static float objectPerimeter = 0.25f; // perimeter of rolling object

    bool first = true; // set to true for first pulse/irregularity . set to false during the cycle

    Vector3 lastPosition; // stores the position of the object when it starts a cycle

    Rigidbody rb; // rigidbody of object

    float starterTime; // stores the time when a new cycle begins
    float curTime; // current time

    //float lastVelocity = 0f;
    //float acceleration;

    float massObject;
    float collisionMagnitude;

    // Use this for initialization
    void Start () {
        HeavyScript = GetComponent<Hv_FilterBased_AudioLib>();
        rb = GetComponent<Rigidbody>();
        massObject = rb.mass;

        ScaleEverythingWithObject();
        objectPerimeter = 0.675f * scaleAvg;

        //freq_modes = new float[10] { 1714.581299f, 1668.823242f, 5049.536133f, 1757.647705f, 2869.299316f, 4390.081787f, 6745.275879f, 13953.515625f, 11743.670654f, 20806.457520f };
        //ampl_modes = new float[10] { 1f, 0.001744f, 0.043746f, 0.001430f, 0.004816f, 0.031406f, 0.068062f, 0.007815f, 0.005319f, 0.006524f };
        
        // Wine bottle - body upper
        freq_modes = new float[10] { 2196.386719f, 2150.628662f, 3945.959473f, 2939.282227f, 2239.453125f, 2104.870605f, 6535.327148f, 4018.634033f, 6489.569092f, 6578.393555f };
        ampl_modes = new float[10] { 1f, 0.244862f, 0.070771f, 0.136772f, 0.055802f, 0.050188f, 0.000222f, 0.084317f, 0.000197f, 0.000196f };
        SetTheFreqs();
        SetTheAmpls();
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        //Debug.Log("World Contact = " + contact.point);
        Vector3 local_vec = transform.InverseTransformPoint(contact.point);
        Debug.Log("Local Contact = " + local_vec.ToString("F4"));
        Debug.Log(Mathf.Sqrt(local_vec.x * local_vec.x + local_vec.y * local_vec.y + local_vec.z * local_vec.z));
        edge_mult = Mathf.Sqrt(local_vec.x * local_vec.x + local_vec.y * local_vec.y + local_vec.z * local_vec.z);
        Debug.Log("edge_mult: "+edge_mult);
        SetTheFreqs();
        SetTheAmpls();

        Hv_FilterBased_AudioLib otherObjectScript = collision.gameObject.GetComponent<Hv_FilterBased_AudioLib>(); //getting audio patch script from colliding object
        collisionMagnitude = 0.5f * massObject * collision.relativeVelocity.magnitude * collision.relativeVelocity.magnitude; // Kinetic energy

        if (otherObjectScript != null)
        {
            //Debug.Log(collisionMagnitude + collisionMagnitude * ((otherObjectScript.qfactor / 5000 + HeavyScript.qfactor / 5000) / 2));
            HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Impactforce, collisionMagnitude + collisionMagnitude * ((otherObjectScript.qfactor / 5000 + HeavyScript.qfactor / 5000) / 2));

            HeavyScript.SendEvent(Hv_FilterBased_AudioLib.Event.Whackimpact);
        }
        else
        {
            //HeavyScript.SetFloatParameter(Hv_John_AudioLib.Parameter.Groundhardness, surfaceScript.surfaceHardness);// set surface's hardness into patch

            HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Impactforce, collisionMagnitude);
            HeavyScript.SendEvent(Hv_FilterBased_AudioLib.Event.Whackimpact);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Velocity, rb.velocity.magnitude); //send veloctiy parameter to patch, placed outside the following condition so that the rolling whoosh sound stops when object stops rolling

        //Scratching
        if (rb.angularVelocity.magnitude < 1f)
        {
            HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Time_scratch, Time.deltaTime * 4000);
        }
        //Rolling
        else
        {
            if (first) // cycle begins, initialize values
            {
                lastPosition = transform.position;
                distanceTravelled = 0;
                pulseIndex = 0;
                first = false;
                starterTime = Time.time;
            }

            distanceTravelled += Vector3.Distance(transform.position, lastPosition); // updates distance travelled by object while rolling
            lastPosition = transform.position;
            //Debug.Log("veloctiy " + rigid.velocity.magnitude);
            //Debug.Log(" angular vel " + rigid.angularVelocity.magnitude);


            if (distanceTravelled > (objectPerimeter / pulsesPerRotation) + pulseIndex * (objectPerimeter / pulsesPerRotation)) // condition true when object has reache the distance correspondant to the pulse within a cycle
            {
                curTime = Time.time - starterTime;
                starterTime = Time.time;

                HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Time_roll, curTime * 3000); //sets how long the rolling noise sound will last. * 1000 to transform from seconds to milliseconds and then * 3 for heuristic purposes
                HeavyScript.SendEvent(Hv_FilterBased_AudioLib.Event.Excite); // sending bang to patch        

                pulseIndex += 1;
            }

            if (distanceTravelled > objectPerimeter) // when cycle is finished reinitialize
            {
                first = true;
            }
        }
    }

    // sets frequency values to the Heavy script
    public void SetTheFreqs()
    {

        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq1, freq_modes[0] * multiplier * edge_mult);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq2, freq_modes[1] * multiplier * edge_mult);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq3, freq_modes[2] * multiplier * edge_mult);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq4, freq_modes[3] * multiplier * edge_mult);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq5, freq_modes[4] * multiplier * edge_mult);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq6, freq_modes[5] * multiplier * edge_mult);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq7, freq_modes[6] * multiplier * edge_mult);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq8, freq_modes[7] * multiplier * edge_mult);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq9, freq_modes[8] * multiplier * edge_mult);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Freq10, freq_modes[9] * multiplier * edge_mult);
    }

    // sets amplitude values to the Heavy script
    public void SetTheAmpls()
    {
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp1, ampl_modes[0]);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp2, ampl_modes[1]);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp3, ampl_modes[2]);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp4, ampl_modes[3]);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp5, ampl_modes[4]);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp6, ampl_modes[5]);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp7, ampl_modes[6]);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp8, ampl_modes[7]);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp9, ampl_modes[8]);
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Amp10, ampl_modes[9]);

    }

    void ScaleEverythingWithObject()
    {
        scaleAvg = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;

        if (scaleAvg > 8.5f)
            scaleAvg = 8.5f;

        // Scale-up
        if (scaleAvg > 1f)
        {
            // Normalization
            scaleAvg /= 10f;
            // Add to the pitch multiplier
            float temp = multiplier + scaleAvg;
            // Apply to the size slider
            HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Size, 2 - temp);
            // Apply to the pitch multiplier
            multiplier = 2 - temp;
            // Re-set the modal frequencies
            SetTheFreqs();
        }
        // Scale-down
        else
        {
            // Subtract from the pitch multiplier
            float temp = multiplier - scaleAvg;
            // Apply to the size slider
            HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Size, 1 + temp);
            // Apply to the pitch multiplier
            multiplier = 1 + temp;
            // Re-set the modal frequencies
            SetTheFreqs();
        }

    }
}
