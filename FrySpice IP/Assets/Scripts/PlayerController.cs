using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	/// <summary>
	/// Author: William T. Fry
	/// Created: 02/19/2020
	/// Desc: A script used to allow keyboard contol of the 
	/// player's position, jumping, and pickups.
	/// </summary>

	//Values for the text representation of coin total and the 
	//count, respectively.
	public Text score;
	private int coins = 0;

	//value denoting maximum speed, always * 1
	public float maxSpeed = 2f;
	
	//truth value denoting direction of player
	bool facingLeft = true;

	//animator value, will be mainly used later, come back to fix
	//comments when animation implemented
	Animator anim;

	//truth value checking for the presence of ground, math
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	//The force by which the player will jump.
	public float jumpForce = 700f;

	//sound variables
	public AudioSource JumpSound;
	public AudioSource CoinCollect;

	Lives lives;
	GameObject player;

	bool one_smack;

	/// <summary>
	/// Method called on the frame when a script is enabled just before
    /// any of the Update methods are called the first time.
	/// </summary>
	void Start()
	{
		//set anim to the animator
		anim = GetComponent<Animator>();

		player = GameObject.FindGameObjectWithTag("Player");
		lives = player.GetComponent<Lives>();

		coins = PlayerPrefs.GetInt("coins", coins);
		Score_Update();

	}

	/// <summary>
	/// Basically Frame-rate independent message for physics calculations, 
    /// has the frequency of the physics system; it is called every fixed 
    /// frame-rate frame. 
	/// </summary>
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

		//calls Flip method to make it so when moving left/right the
		//player faces the right direction.
		if (move < 0 && !facingLeft)
		{
			Flip();
		} else if (move > 0 && facingLeft) {
			Flip();
		}
	}

	/// <summary>
    /// Method called every frame.
    /// </summary>
	void Update()
	{

		//if grounded and spacebar input detected, no longer grounded
		//& the jumpforce gets added
		if (grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			JumpSound.Play();
		}

	}

	/// <summary>
    /// Causes the related object to flip along the y-axis.
    /// </summary>
	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	/// <summary>
	/// This method is called whenever another object enters a trigger collider
    /// attached to the defined object.
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag("Coin"))
        {
			other.gameObject.SetActive(false);
			coins += 1;

			//send new val to playerprefs
			PlayerPrefs.SetInt("coins", coins);
			CoinCollect.Play();
			Score_Update();
        }

		if (one_smack == false)
        {
			if (other.gameObject.CompareTag("FallKill"))
			{
				one_smack = true;
				if (lives.lives >= 0)
				{
					lives.Damage();
				}
			}
		}

		if (other.gameObject.CompareTag("Goal"))
        {
			SceneManager.LoadScene(2);
        }
		
    }

	public void Vulnerability()
    {
		one_smack = false;
    }

	/// <summary>
    /// Method by which updates score strings.
    /// </summary>
	void Score_Update()
    {
		score.text = "Coins: " + coins.ToString();
	}
}