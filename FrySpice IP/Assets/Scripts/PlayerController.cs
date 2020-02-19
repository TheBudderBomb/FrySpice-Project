using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	/// <summary>
    /// Author: William T. Fry
    /// Created: 02/19/2020
    /// A script used to allow keybopard contol of the player's position
    /// </summary>
    

	//value denoting maximum speed, always * 1
	public float maxSpeed = 2f;
	
	//truth value denoting direction of player
	bool facingLeft = true;

	//animator value, will be mainly used later, come back to fix comments when animation implemented
	Animator anim;

	//truth value checking for the presence of ground, math
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	//The force by which the player will jump.
	public float jumpForce = 700f;

	//init
	void Start()
	{
		//set anim to the animator
		anim = GetComponent<Animator>();

	}


	void FixedUpdate()
	{
		//set vSpeed
		anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		//set grounded boolean
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		//set ground bool in anim to animate grounding
		anim.SetBool("Ground", grounded);

		//moving value for arrow keys/wasd input
		float move = Input.GetAxis("Horizontal");
												 
		//move the rigidbody component on player 
		GetComponent<Rigidbody2D>().velocity = new Vector3(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		//set movement speed
		anim.SetFloat("Speed", Mathf.Abs(move));

		//calls Flip method to make it so when moving left/right the player faces the right direction.
		if (move < 0 && !facingLeft)
		{
			Flip();
		} else if (move > 0 && facingLeft) {
			Flip();
		}
	}

	void Update()
	{

		//if grounded and spacebar input detected, no longer grounded & the jumpforce gets added
		if (grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			GetComponent<AudioSource>().Play();
		}


	}

	//method for flipping the player sprite along the y axis.
	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}