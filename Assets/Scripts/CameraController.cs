using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;

    private Vector3 targetPosition, mousePosition;

    public Vector2 min, max;

    public float distanceMultiplier;

   // Use this for initialization
   void Start () {
        
    }
	
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.x = (mousePosition.x - Screen.width / 2) * distanceMultiplier;
        mousePosition.y = (mousePosition.y - Screen.height / 2) * distanceMultiplier;

        Debug.Log(mousePosition);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x),
            Mathf.Clamp(transform.position.y, min.y, max.y),-10f);
    }

	// Update is called once per frame
	void FixedUpdate () {

        transform.position = new Vector3(followTarget.transform.position.x + mousePosition.x,
            followTarget.transform.position.y + mousePosition.y, transform.position.z);
	}
}
