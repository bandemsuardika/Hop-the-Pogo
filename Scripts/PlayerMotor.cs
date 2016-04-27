using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private Vector3 moveVector;

	private float playerSpeed = 5.0f;
	private float verticalVelocity = 0.0f;
	private float gravity = 9.8f;

	private float animationDuration = 2.0f;
	private float startTime;

	private bool isDead = false;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;

		//start animation
		if (Time.time - startTime < animationDuration) {
			controller.Move (Vector3.forward * (playerSpeed / 2.5f) * Time.deltaTime);
			return;
		}
		//player movement controller
		moveVector = Vector3.zero;
		if (controller.isGrounded) {
			verticalVelocity = -0.5f;
		} else {
			verticalVelocity -= gravity * Time.deltaTime;
		}

		//X - Left Right
		moveVector.x = Input.GetAxis("Horizontal") * playerSpeed;
		//Y - Up Down
		moveVector.y = verticalVelocity;
		//Z - Forward Backward
		moveVector.z = Input.GetAxis("Vertical") * playerSpeed;
		//moveVector.z = playerSpeed;

		controller.Move (moveVector * Time.deltaTime);
	}

	//speed modifier --> difficulty
	public void SetSpeed(float modifier){
		playerSpeed = 5.0f + modifier;
	}


	//it is being called every time our collider hit something --> death condition
	private void OnControllerColliderHit(ControllerColliderHit hit){
		if (hit.point.z > transform.position.z + controller.radius)
			Death ();
	}

	//death function
	private void Death(){
		isDead = true;
		GetComponent<Score> ().onDeath ();
		Debug.Log ("You Dead");
	}
}
