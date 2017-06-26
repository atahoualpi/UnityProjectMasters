using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    //public GameObject player;       //Public variable to store a reference to the player game object


    //private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    //void Start()
    //{
    //    //Calculate and store the offset value by getting the distance between the player's position and camera's position.
    //    offset = transform.position - player.transform.position;
    //}

    // LateUpdate is called after Update each frame
    //void LateUpdate()
    //{
    //    // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
    //    transform.position = player.transform.position + offset;
    //}

    //Lerp
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }

}
