using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;

    public double health;

    private Rigidbody2D rigidbody2D;

    private Vector2 velocity;

	// Use this for initialization
	void Start () {

        rigidbody2D = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        velocity = moveInput.normalized * Speed;

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
