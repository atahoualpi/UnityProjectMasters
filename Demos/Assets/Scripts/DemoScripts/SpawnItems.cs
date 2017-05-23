using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour {

    public Transform[] SpawnPoints;
    public float spawnTime = 1.5f;

    //public GameObject Object3D;
    public GameObject[] Objects3D;

    public static bool keepSpawning = true;

    // Use this for initialization
    void Start () {
        //InvokeRepeating("SpawnObjects", spawnTime, spawnTime);
        StartCoroutine(SpawnAtIntervals(spawnTime)); // Or whatever delay we want.
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnAtIntervals(float secondsBetweenSpawns)
    {
        // Repeat until keepSpawning == false or this GameObject is disabled/destroyed.
        while (keepSpawning)
        {
            // Put this coroutine to sleep until the next spawn time.
            yield return new WaitForSeconds(secondsBetweenSpawns);

            // Now it's time to spawn again.
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);

        //Instantiate(Object3D, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
        int objIndex = Random.Range(0, Objects3D.Length);
        Instantiate(Objects3D[objIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
    }

}
