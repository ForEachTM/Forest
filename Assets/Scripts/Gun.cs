using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;

    private float spawnRate;

    public float spawnTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (spawnRate <= 0)
        {
            Instantiate(bullet, bullet.transform.position, Quaternion.identity);
            spawnRate = spawnTime;
        }
        else
        {
            spawnRate -= Time.deltaTime;
        }

    }
}
