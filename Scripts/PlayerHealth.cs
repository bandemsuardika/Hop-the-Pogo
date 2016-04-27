using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int playerHealth = 3;
	public float maxFallDistance = -2;
	public Vector3 lastKnownPlace;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.y <= maxFallDistance) {
			playerHealth -= 1;

		}
		if (playerHealth == 0) {
			
		}
	}
	void onCollisionEnter(Collision other){
		ContactPoint contact = other.contacts [0];
		lastKnownPlace = contact.point;
	}
}
