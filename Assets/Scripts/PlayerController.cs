using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Public variables
	public float jumpForce = 500.0f; //Base force for a jump
	public float speed = 10.0f; //Speed of the player

	//MonoBehaviour object components
	Rigidbody2D rb;
	CircleCollider2D cc;
	SpriteRenderer sr;

	void Awake(){
		//Get references to our components
		rb = GetComponent<Rigidbody2D>();
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveHorizontal(Input.GetAxis("Horizontal")); //Move/adjust our horizontal velocity based on our horizontal input
		if(Input.GetButtonDown("Jump")){ //If we pushed the jump button down this frame...
			Jump(); //Lets jump!
		}
	}

	void OnCollisionEnter2D(Collision2D coll) { //On the frame this object's Collider collides with another collider...
		if (coll.gameObject.name == "Speed Powerup"){  //Check if we've hit a speed powerup
			Debug.Log("Powerup picked up!"); //Lets let the console know we've hit a powerup
			speed *= 1.5f; //Increase our speed by 150%!
			Destroy(coll.gameObject); //Destroy the powerup
		}
	}

	void MoveHorizontal(float input){ //Takes a input from -1.0 to 1.0
		Vector2 moveVel = rb.velocity; //Get our current rigidbody's velocity
		moveVel.x = input * speed; //Set the new x velocity to be the given input times our speed
		rb.velocity = moveVel; //Update our rigidbody's velocity
	}

	void Jump(){
		//Replace "true" with "IsGrounded()" if you want to stop the infinite jumps
		if(true){
			rb.AddForce(Vector2.up * jumpForce); //Add a upward force to our rigidbody
		}
	}

	/* Not to be presented, but this will return true if you are on the ground, false otherwise
	bool IsGrounded(){ //Returns true if we are on the ground, false otherwise
		float spriteRange = cc.radius*transform.localScale.y + 0.05f; //Get the point directly under the player
		float raycastRange = spriteRange + 0.05f; //How far should we do the linecast

		//Perform a linecast hit check for colliders
		RaycastHit2D hit = Physics2D.Linecast(transform.position - new Vector3(0, spriteRange, 0), transform.position - new Vector3(0, raycastRange, 0));
		
		//Debug.DrawLine(transform.position - new Vector3(0, spriteRange, 0), transform.position - new Vector3(0, raycastRange, 0)); //Show the linecast we're preforming

		if(hit.collider == null){ //If the raycast didn't hit anything
			return false;
		} else if(hit.collider.tag == "Platform"){ //If it hit a ground's collider
			return true;
		} else { //If it hit anything else
			return false;
		}		
	}
	*/
}
