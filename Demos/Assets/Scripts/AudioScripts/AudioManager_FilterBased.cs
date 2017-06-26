using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModalDataScript_FilterBased))]
[RequireComponent(typeof(Hv_FilterBased_AudioLib))]
[RequireComponent(typeof(Rigidbody))]
[ExecuteInEditMode]
public class AudioManager_FilterBased : MonoBehaviour
{
    //[HideInInspector]
    public Hv_FilterBased_AudioLib HeavyScript;
    public ModalDataScript_FilterBased SetDataScript;

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

    [HideInInspector]
    public bool isSolid;

    float prevScale;

    void Awake()
    {
        HeavyScript = GetComponent<Hv_FilterBased_AudioLib>();
        SetDataScript = GetComponent<ModalDataScript_FilterBased>();

        //SetDataScript.SetGlassTop();
        //SetDataScript.SetTheFreqs();
        //SetDataScript.SetTheAmpls();
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Debug.Log(this.gameObject.GetComponent<Collider>().bounds.size);
        massObject = rb.mass;

        //if (isSolid)
        //    rb.mass *= 10;

        ScaleEverythingWithObject();

        SetDataScript.IdentifyObject(this.transform, 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            prevScale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
            transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            ScaleRealTime(prevScale); Debug.Log(transform.localScale);
        }
        if (Input.GetKeyDown("d"))
        {
            prevScale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            ScaleRealTime(prevScale);
            Debug.Log(transform.localScale);
        }
    }

    //void FixedUpdate()
    //{
    //    acceleration = (rigid.velocity.magnitude - lastVelocity) / Time.fixedDeltaTime;
    //    lastVelocity = rigid.velocity.magnitude;
    //    //Debug.Log(rigid.velocity);
    //}

    void OnCollisionEnter(Collision collision)
    {
        // determine which point of the object was struct and set the corresponding data
        SetDataScript.IdentifyObject(this.transform, collision.contacts[0].thisCollider.gameObject.transform.GetSiblingIndex());

        //IMPORTANT!!
        //find out whether the object colliding is a surface or other modal object. 
        //If modal object, find material and modify hardness and maybe collision magnitude ( for example two metal objects should have a very bright sound) 
        //Could use the 2 objects' Q factors, normalize them and use the resulting mean of both to find the collision magnitude

        //SurfaceScript surfaceScript = collision.gameObject.GetComponent<SurfaceScript>(); // getting script attached on surface
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

        //Debug.Log(collisionMagnitude);
        //Debug.Log(massObject * acceleration);
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

    void ScaleEverythingWithObject()
    {
        float avgScale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;

        if (avgScale > 8.5f)
            avgScale = 8.5f;

        // Scale-up
        if (avgScale > 1f)
        {
            // Normalization
            avgScale /= 10f;
            // Add to the pitch multiplier
            float temp = (2-SetDataScript.multiplier) +avgScale;
            // Apply to the size slider
            HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Size, 2-temp);
            // Apply to the pitch multiplier
            SetDataScript.multiplier = 2-temp;
            // Re-set the modal frequencies
            SetDataScript.SetTheFreqs();
        }
        // Scale-down
        else
        {
            // Subtract from the pitch multiplier
            float temp = SetDataScript.multiplier - avgScale;
            // Apply to the size slider
            HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Size, 1 + temp);
            // Apply to the pitch multiplier
            SetDataScript.multiplier = 1+ temp;
            // Re-set the modal frequencies
            SetDataScript.SetTheFreqs();
        }
    }

    void ScaleRealTime(float prevScale)
    {
        float avgScale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;

        if (avgScale > 8.5f)
            avgScale = 8.5f;

        // Scale-up
        //if (avgScale > 1f)
        if (avgScale > prevScale)
        {
            // Normalization
            avgScale /= 10f;
            // Add to the pitch multiplier
            float temp = (2 - SetDataScript.multiplier) + avgScale;
            // Apply to the size slider
            HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Size, 2 - temp);
            // Apply to the pitch multiplier
            SetDataScript.multiplier = 2 - temp;
            // Re-set the modal frequencies
            SetDataScript.SetTheFreqs();
        }
        // Scale-down
        else if (avgScale < prevScale)
        {
            // Subtract from the pitch multiplier
            float temp = SetDataScript.multiplier - avgScale;
            // Apply to the size slider
            HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Size, 1 + temp);
            // Apply to the pitch multiplier
            SetDataScript.multiplier = 1 + temp;
            // Re-set the modal frequencies
            SetDataScript.SetTheFreqs();
        }

    }
}
