using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float velocity;

    Vector3 mousePosition;
    Vector3 direction;

    void Start()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;

        transform.position = target.position;

        direction = (mousePosition - transform.position).normalized;

        transform.up = direction;
    }

    void Update()
    {
        transform.position += direction * velocity * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (collider.gameObject.tag != "Player")
        {
           
           Destroy(gameObject);
            
        }
    }

}
