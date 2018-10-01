using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    public float velocity;

    private Transform target;

    private SpriteRenderer render;

    private bool facingRight = false;

    // Use this for initialization
    void Start () {
        render = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Flip()
    {

        if (target.position.x > transform.position.x && !facingRight || target.position.x < transform.position.x && facingRight)
        {
            render.flipX = facingRight = !facingRight;
        }


    }

    // Update is called once per frame
    void Update () {
        Flip();

        transform.position = Vector2.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
	}

}
