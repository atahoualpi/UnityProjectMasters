﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialFilterBased : MonoBehaviour {

    private float changeTime = 0.5f;
    private GameObject currObj;
    private Hv_FilterBased_AudioLib HeavyScript;
    public float adder = 500f;
    private bool change = true;
    public Renderer rend;

    // Use this for initialization
    void Start () {
        //currObj = GetComponent<SpawnItems>().Objects3D[0];
        currObj = gameObject;
        HeavyScript = currObj.GetComponent<Hv_FilterBased_AudioLib>();
        //currObj.GetComponent<DestroyItems>().destroyTime = 6f;
        //GetComponent<SpawnItems>().spawnTime = 3f;
        StartCoroutine(ChngMat(changeTime)); // Or whatever delay we want.
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ChngMat(float secondsBetweenChange)
    {
        // Repeat until change == false or this GameObject is disabled/destroyed.
        while (change)
        {
            // Put this coroutine to sleep until the next change time.
            yield return new WaitForSeconds(secondsBetweenChange);

            // Now it's time to change again.
            ChangeMat();
        }
    }

    void ChangeMat()
    {
        adder += 200f;
        HeavyScript.SetFloatParameter(Hv_FilterBased_AudioLib.Parameter.Qfactor, adder);
        //if (adder >= 5000f)
        //{
        //    change = false;
        //    SpawnItems.keepSpawning = false;
        //}
    }
}
