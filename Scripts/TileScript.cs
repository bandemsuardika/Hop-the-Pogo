using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	private float fallDelay = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// triggered when exit the colider
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			TileManager.Instance.spawnTile();
			Debug.Log ("Spawn tile");
			StartCoroutine (FallDown ());
		}
	}

	IEnumerator FallDown(){
		yield return new WaitForSeconds (fallDelay);
		GetComponent<Rigidbody> ().isKinematic = false;
		Debug.Log ("Fall down");
		yield return new WaitForSeconds (2);
		switch (gameObject.name){
		case "TopTile":
			TileManager.Instance.TopTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "LeftTile":
			TileManager.Instance.LeftTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "RightTile":
			TileManager.Instance.RightTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "BottomTile":
			TileManager.Instance.BottomTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		}
	}
}
