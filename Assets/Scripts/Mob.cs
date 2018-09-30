using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    public float velocity;

    private Transform target;

    private bool facingRight = false;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;

        if (target.position.x > transform.position.x && !facingRight || target.position.x < transform.position.x && facingRight)
        {
            facingRight = !facingRight;

            scale.x *= -1;

            transform.localScale = scale;
        }


    }

    // Update is called once per frame
    void Update () {
        Flip();

        transform.position = Vector2.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
	}

}
