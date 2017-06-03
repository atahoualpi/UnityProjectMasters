using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1 : MonoBehaviour {
    public Hv_FilterRolling_AudioLib HeavyScript;
    public ModalDataScript_FilterBased SetDataScript;
    // Use this for initialization

    void Awake()
    {
        HeavyScript = GetComponent<Hv_FilterRolling_AudioLib>();
        SetDataScript = GetComponent<ModalDataScript_FilterBased>();

        //SetDataScript.SetGlassTop();
        //SetDataScript.SetTheFreqs();
        //SetDataScript.SetTheAmpls();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
