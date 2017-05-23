using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModalDataScript_Sinusoidal))]
[RequireComponent(typeof(Hv_SinusRolling_AudioLib))]
[RequireComponent(typeof(Rigidbody))]
public class AudioManager_Sinusoidal : MonoBehaviour
{
    //[HideInInspector]
    public Hv_SinusRolling_AudioLib HeavyScript;
    public ModalDataScript_Sinusoidal SetDataScript;

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

    int caseSwitch = 1;


    [HideInInspector]
    public bool isSolid;

    void Awake()
    {
        HeavyScript = GetComponent<Hv_SinusRolling_AudioLib>();
        SetDataScript = GetComponent<ModalDataScript_Sinusoidal>();

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
        Hv_SinusRolling_AudioLib otherObjectScript = collision.gameObject.GetComponent<Hv_SinusRolling_AudioLib>(); //getting audio patch script from colliding object with sinusRolling script attached
        collisionMagnitude = 0.5f * massObject * collision.relativeVelocity.magnitude * collision.relativeVelocity.magnitude;
        //collisionMagnitude = collision.impulse.magnitude;
        //Debug.Log("Impulse: " + collisionMagnitude);
        //if (collisionMagnitude <= 10f)
        //{

            switch (caseSwitch)
            {
                case 1:
                    if (otherObjectScript != null)
                    {
                        HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Impact_force1, collisionMagnitude + collisionMagnitude * ((otherObjectScript.qfactor / 5000 + HeavyScript.qfactor / 5000) / 2) / 2);
                    }
                    else
                    {
                        HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Impact_force1, collisionMagnitude);
                        //Debug.Log("Impulse: " + collisionMagnitude);
                    }
                    HeavyScript.SendEvent(Hv_SinusRolling_AudioLib.Event.Whack1);
                    //Debug.Log("whack1");
                    caseSwitch = 2;
                    break;
                case 2:
                    if (otherObjectScript != null)
                    {
                        HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Impact_force2, collisionMagnitude + collisionMagnitude * ((otherObjectScript.qfactor / 5000 + HeavyScript.qfactor / 5000) / 2) / 2);
                    }
                    else
                    {
                        HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Impact_force2, collisionMagnitude);
                    }
                    HeavyScript.SendEvent(Hv_SinusRolling_AudioLib.Event.Whack2);
                    //Debug.Log("whack2");
                    caseSwitch = 3;
                    break;
                case 3:
                    if (otherObjectScript != null)
                    {
                        HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Impact_force3, collisionMagnitude + collisionMagnitude * ((otherObjectScript.qfactor / 5000 + HeavyScript.qfactor / 5000) / 2) / 2);
                    }
                    else
                    {
                        HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Impact_force3, collisionMagnitude);
                    }
                    HeavyScript.SendEvent(Hv_SinusRolling_AudioLib.Event.Whack3);
                    //Debug.Log("whack3");
                    caseSwitch = 1;
                    break;
            }

        //}
        //else
        //{
        //    Debug.Log("Impact magnitude not suitable for audio");
        //}
    }

    void OnCollisionStay(Collision collision)
    {
        HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Velocity, rb.velocity.magnitude); //send veloctiy parameter to patch, placed outside the following condition so that the rolling whoosh sound stops when object stops rolling

        //Scratching
        if (rb.angularVelocity.magnitude < 1f)
        {
            HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Time_scratch, Time.deltaTime * 4000);
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

                HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Time_roll, curTime * 3000); //sets how long the rolling noise sound will last. * 1000 to transform from seconds to milliseconds and then * 3 for heuristic purposes
                HeavyScript.SendEvent(Hv_SinusRolling_AudioLib.Event.Excite); // sending bang to patch        

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

        if (avgScale > 1f)
        {
            avgScale /= 10f;
            float temp = SetDataScript.multiplier +avgScale;
            HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Size, 2-temp);
            SetDataScript.multiplier = 2-temp;
            SetDataScript.SetTheFreqs();
        }
        else
        {
            //avgScale /= 10f;
            float temp = SetDataScript.multiplier - avgScale;
            HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Size, 1 + temp);
            SetDataScript.multiplier = 1+ temp;
            SetDataScript.SetTheFreqs();
        }

    }
}
