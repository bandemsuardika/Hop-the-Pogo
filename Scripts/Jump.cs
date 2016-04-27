using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]

public class Jump : MonoBehaviour {

	protected CharacterController control;
	protected Vector3 move = Vector3.zero;

	public float walkspeed = 1f;
	public float runspeed = 5f;
	public float turnspeed = 90f;
	public float jumpspeed = 5f;

	protected bool jump;
	protected bool running;

	protected Vector3 gravity = Vector3.zero; 

	// Use this for initialization
	void Start () {
		control = GetComponent<CharacterController> ();
		if (!control) {
			Debug.LogError ("Unity.Start()" + name + "has no character");
			enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			move *= runspeed;
		} else {
			move *= walkspeed;
		}
		if (!control.isGrounded) {
			gravity += Physics.gravity * Time.deltaTime;
		} else {
			gravity = Vector3.zero;
			if (jump) {
				gravity.y = jumpspeed;
				jump = false;
			}
		}
		move += gravity;
		control.Move (move * Time.deltaTime);
	}
}
