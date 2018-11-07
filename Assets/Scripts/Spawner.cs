using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnSpots;
    private float tmpEntreSpawns;
    public float tmpInicialEntreSpawns;

	// Use this for initialization
	void Start () {
        tmpEntreSpawns = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (tmpEntreSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(enemy,spawnSpots[randPos].position, Quaternion.identity);
            tmpEntreSpawns = tmpInicialEntreSpawns;
            if(tmpInicialEntreSpawns>=1)
            {
                tmpInicialEntreSpawns -= 0.25f;
            }
        } else
        {
            tmpEntreSpawns -= Time.deltaTime;
        }
	}
}
