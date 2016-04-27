using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float moveSpeed = 2;
	//public float rotateSpeed = 180;
	public float jumpSpeed = 2;
	public float gravity = 9.8f;
	CharacterController controller;
	public Vector3 currentMovement;
	public Vector3 currentPlace;
	public Vector3 lastKnownPlace;
	public int playerHealth = 1;
	public float maxFallDistance = -2;
	public Vector3 startPosition;
	private bool isDead;
	public GameObject particle;
	public GameObject restart;

	// Use this for initialization
	void Start () {
		restart.SetActive (false);
		isDead = false;
		controller = GetComponent<CharacterController> ();
		startPosition = GameObject.FindGameObjectWithTag ("Start").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//player move on z axis
		transform.Translate (0, 0, -Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime);
		//player move on x axis
		currentMovement = new Vector3 (Input.GetAxis ("Vertical") * moveSpeed, currentMovement.y, 0);
		//currentmovement = transform.rotation * currentmovement;

		//check if touching the ground
		if (!controller.isGrounded) {
			currentMovement -= new Vector3 (0, gravity * Time.deltaTime, 0);	//apply gravity
		} else {
			currentMovement.y = 0;
		}

		currentPlace = transform.position;

		//jump if toch the ground and press space button
		if (controller.isGrounded && !Input.GetButtonDown ("Jump")) {
			currentMovement.y = jumpSpeed;
			lastKnownPlace = currentPlace;
		}

		controller.Move (currentMovement * Time.deltaTime);

		//check if player fall
		if (transform.position.y <= maxFallDistance && isDead) {
			currentPlace = lastKnownPlace;
			currentMovement = new Vector3(0,0,0);
			transform.position = new Vector3(currentPlace.x, 1, currentPlace.z);
			playerHealth -= 1;
		}
	}

	/*void OnCollisionEnter(Collision col){
		
	}*/

	void OnTriggerEnter(Collider other){
		if(other.tag == "Pickup"){
			other.gameObject.SetActive (false);
			Instantiate (particle, transform.position, Quaternion.identity);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Tile") {
			RaycastHit hit;
			Ray downRay = new Ray (transform.position, -Vector3.up);
			if (!Physics.Raycast (downRay, out hit)) {
				playerHealth -= 1;
			}
			//kill player
			if (playerHealth <= 0) {
				isDead =true;
				restart.SetActive (true);
				if (transform.childCount > 0) {
					transform.GetChild (0).transform.parent = null;
				}
				/*	lastKnownPlace = startPosition;
			transform.position = new Vector3 (startPosition.x, 1, startPosition.z);
		*/
			}
		}
	}
}
