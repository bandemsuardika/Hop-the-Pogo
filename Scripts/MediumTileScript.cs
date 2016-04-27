using UnityEngine;
using System.Collections;

public class MediumTileScript : MonoBehaviour {

	private float fallDelay = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// triggered when exit the colider
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			MediumPathGenerator.Instance.spawnTile ();
			Debug.Log ("Spawn tile");
			StartCoroutine (FallDown ());
		}
	}

	IEnumerator FallDown(){
		yield return new WaitForSeconds (fallDelay);
		//isKinematic true to stop fall down
		GetComponent<Rigidbody> ().isKinematic = false;
		Debug.Log ("Fall down");
		yield return new WaitForSeconds (2);
		switch (gameObject.name){
		case "TopTile":
			MediumPathGenerator.Instance.TopTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "LeftTile":
			MediumPathGenerator.Instance.LeftTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "RightTile":
			MediumPathGenerator.Instance.RightTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "BottomTile":
			MediumPathGenerator.Instance.BottomTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "CenterTile":
			MediumPathGenerator.Instance.CenterTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "TopLeftTile":
			MediumPathGenerator.Instance.TopLeftTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "TopRightTile":
			MediumPathGenerator.Instance.TopRightTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "BottomLeftTile":
			MediumPathGenerator.Instance.BottomLeftTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		case "BottomRightTile":
			MediumPathGenerator.Instance.BottomRightTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);
			break;
		}
	}
}
