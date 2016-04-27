using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	private ParticleSystem particle;

	// Use this for initialization
	void Start () {
		particle = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!particle.isPlaying) {
			Destroy (gameObject);
		}
	}
}
