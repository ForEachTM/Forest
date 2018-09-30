using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour {

    public GameObject mob;

    private float spawnRate;

    public float spawnTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (spawnRate <= 0)
        {
            Vector2 position = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            Instantiate(mob, position, Quaternion.identity);
            spawnRate = spawnTime;
        }
        else
        {
            spawnRate -= Time.deltaTime;
        }
	}
}
