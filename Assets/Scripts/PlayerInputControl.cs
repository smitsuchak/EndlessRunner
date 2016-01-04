using UnityEngine;
using System.Collections;

public class PlayerInputControl : MonoBehaviour {

	public GameManager control;
	CharacterController controller;
	bool isGrounded= false;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	public Animator animator;
	public GameObject explosionPowerUpPrefab;
	public GameObject explosionObstaclepPrefab;

	//start 
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update (){
		if (controller.isGrounded) {
			if (SystemInfo.deviceType != DeviceType.Handheld) {
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);  //get keyboard input to move in the horizontal direction
			} else {
				moveDirection = new Vector3 (Input.acceleration.x, 0, 0);  //get keyboard input to move in the horizontal direction

			}
			moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
			moveDirection *= speed;            //increase the speed of the movement by the factor "speed" 

			if (Input.GetButton ("Jump")) {         
				moveDirection.y = jumpSpeed;         //add the jump height to the character
			}
			if(controller.isGrounded)           //set the flag isGrounded to true if character is grounded
				isGrounded = true;
		}

		moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity  
		controller.Move(moveDirection * Time.deltaTime);      //Move the controller
	}

	//check if the character collects the powerups or the snags
	void OnTriggerEnter(Collider other)
	{               
		if(other.gameObject.name == "Powerup(Clone)")
		{
			control.PowerupCollected();
			// explode if specified
			if (explosionPowerUpPrefab != null) {
				Instantiate (explosionPowerUpPrefab, transform.position, Quaternion.identity);
			}
		}
		else if(other.gameObject.name == "Obstacle(Clone)" && isGrounded == true)
		{
			//Debug.LogError ("Alcohol Collected ");
			control.AlcoholCollected();
			// obstacle if specified
			if (explosionObstaclepPrefab != null) {
				Instantiate (explosionObstaclepPrefab, transform.position, Quaternion.identity);
			}
		}
	
		other.gameObject.SetActive(false);

		Destroy(other.gameObject);

	}

}
