using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingsScript : MonoBehaviour {

    AudioSource aSource;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        
        aSource = collision.contacts[0].thisCollider.gameObject.GetComponent<AudioSource>();
        aSource.Play();
    }
}
