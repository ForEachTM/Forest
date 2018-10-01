using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;

    public float velocity;

    private Vector3 targetPosition, mousePosition;

    public Vector2 min, max;

	// Use this for initialization
	void Start () {

    }
	
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x *= 0.0625f;
        mousePosition.y *= 0.125f;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x), Mathf.Clamp(transform.position.y, min.y, max.y),-10f);
    }

	// Update is called once per frame
	void FixedUpdate () {

        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10f);

        transform.position = Vector3.Lerp(transform.position + mousePosition,targetPosition,velocity*Time.fixedDeltaTime);

	}
}
