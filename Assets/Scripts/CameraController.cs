using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;

    public float velocity;

    private Vector3 targetPosition;

    public float minX, minY, maxX, maxY;

    private float PPU = 100f;

	// Use this for initialization
	void Start () {
        minX /= PPU;
        minY /= PPU;

        maxX /= PPU;
        maxY /= PPU;
    }
	
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f), Mathf.Clamp(transform.position.y, -5f, 5f),-10f);

        /*if (transform.position.x <= minX)
        {
            transform.position = new Vector3(minX, transform.position.y, -10f);
        }else if (transform.position.x >= maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, -10f);
        }

        if (transform.position.y <= minY)
        {
            transform.position = new Vector3(transform.position.x, minY, -10f);
        }
        else if (transform.position.y >= maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, -10f);
        }*/
    }

	// Update is called once per frame
	void FixedUpdate () {

        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10f);

        transform.position = Vector3.Lerp(transform.position,targetPosition,velocity*Time.fixedDeltaTime);

	}
}
