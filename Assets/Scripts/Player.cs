using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;

    public double health;

    public Animator animator;

    private Rigidbody2D rigidbody2D;

    private SpriteRenderer render;

    private Vector2 velocity;

    private bool facingRight = false;

	// Use this for initialization
	void Start () {

        rigidbody2D = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        velocity = moveInput.normalized * Speed;

        animator.SetFloat("Velocity", Mathf.Abs(moveInput.x)+Mathf.Abs(moveInput.y));

        //Flip();
        BetterFlip();
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;

        if (velocity.x > 0 && !facingRight || velocity.x < 0 && facingRight)
        {
            facingRight = !facingRight;
            
            scale.x *= -1;

            transform.localScale = scale;
        }

 
    }

    private void BetterFlip()
    {
        if (velocity.x > 0 && !facingRight || velocity.x < 0 && facingRight)
        {
            render.flipX = facingRight = !render.flipX;
        }
    }

    private void FixedUpdate(){

        rigidbody2D.MovePosition(rigidbody2D.position + velocity * Time.fixedDeltaTime);

    }

    void OnTriggerStay2D(Collider2D collider)
    {

        if(collider.gameObject.tag == "Mob")
        {
            health -= 0.5;
        }
            
    }
}
