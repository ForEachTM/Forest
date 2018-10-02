using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //public float speed;     --use Manager.VALS.PLAYER_HEALTH for this
    //public double health;   --use Manager.VALS.PLAYER_SPEED for this

    public Animator animator;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer render;

    private Vector2 velocity;

    private bool facingRight = false;

	// Use this for initialization
	void Start () {

        rigidbody2D = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();

        StartCoroutine(Init()); 
    }

    IEnumerator Init()
    {
        yield return new WaitForEndOfFrame();

        // Load values from manager values
        float
            x = Manager.VALS.PLAYER_X,
            y = Manager.VALS.PLAYER_Y;

        transform.position = new Vector2(x, y);
        StartCoroutine(UpdateValues());
    }

    IEnumerator UpdateValues()
    {
        yield return new WaitForSeconds(1);

        // Update data in manager
        Manager.VALS.PLAYER_X = transform.position.x;
        Manager.VALS.PLAYER_Y = transform.position.y;
        StartCoroutine(UpdateValues());
    }

	
	// Update is called once per frame
	void Update () {
		
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        velocity = moveInput.normalized * Manager.VALS.PLAYER_SPEED;

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
            Manager.VALS.PLAYER_HEALTH -= 0.5;
        }
            
    }
}
