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

        Flip();
        
    }

    private void Flip()
    {
        if (velocity.x > 0 && !facingRight || velocity.x < 0 && facingRight)
        {
            render.flipX = facingRight = !facingRight;
        }
    }

    private void FixedUpdate(){

        rigidbody2D.MovePosition(rigidbody2D.position + velocity * Time.fixedDeltaTime);

    }

    public Vector2 GetVel()
    {
        return velocity;
    } 

    void OnTriggerStay2D(Collider2D collider)
    {

        if(collider.gameObject.tag == "Mob")
        {
            health -= 0.5;
        }
            
    }
}
