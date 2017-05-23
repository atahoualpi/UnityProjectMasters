using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    Text material;
    float Qfactor;

	// Use this for initialization
	void Start () {
        if (GameObject.Find("SpawnPoints").GetComponent<ChangeMaterialFilterBased>() != null)
            Qfactor = GameObject.Find("SpawnPoints").GetComponent<ChangeMaterialFilterBased>().adder;
        else
            Qfactor = GameObject.Find("SpawnPoints").GetComponent<ChangeMaterialSinusoidal>().adder;

        material = GameObject.Find("Canvas/Material").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("SpawnPoints").GetComponent<ChangeMaterialFilterBased>() != null)
            Qfactor = GameObject.Find("SpawnPoints").GetComponent<ChangeMaterialFilterBased>().adder;
        else
            Qfactor = GameObject.Find("SpawnPoints").GetComponent<ChangeMaterialSinusoidal>().adder;

        //Debug.Log(Qfactor);
        if (Qfactor <= 1300)
        {
            ChangeText("Plastic");
        }
        else if(Qfactor <= 2200)
        {
            ChangeText("Wood");
        }
        else if (Qfactor <= 3200)
        {
            ChangeText("Ceramic");
        }
        else if (Qfactor <= 3600)
        {
            ChangeText("Glass");
        }
        else
        {
            ChangeText("Metal");
        }
    }

    void ChangeText(string theMat)
    {
        material.text = theMat;
    }
}
