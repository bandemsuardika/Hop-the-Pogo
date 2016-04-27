using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MediumPathGenerator : MonoBehaviour {

	private int childCount;
	private int randomIndex;
	private int randomChild;

	public GameObject currentTile;
	public GameObject[] tilePrefabs;

	private static MediumPathGenerator instance;

	private Stack<GameObject> leftTiles = new Stack<GameObject>();
	public Stack<GameObject> LeftTiles{
		get{ return leftTiles; }
		set{ leftTiles = value; }
	}
	private Stack<GameObject> rightTiles = new Stack<GameObject>();
	public Stack<GameObject> RightTiles{
		get{ return rightTiles; }
		set{ rightTiles = value; }
	}
	private Stack<GameObject> topTiles = new Stack<GameObject>();
	public Stack<GameObject> TopTiles{
		get{ return topTiles; }
		set{ topTiles = value; }
	}
	private Stack<GameObject> bottomTiles = new Stack<GameObject>();
	public Stack<GameObject> BottomTiles{
		get{ return bottomTiles; }
		set{ bottomTiles = value; }
	}
	private Stack<GameObject> centerTiles = new Stack<GameObject>();
	public Stack<GameObject> CenterTiles{
		get{ return centerTiles; }
		set{ centerTiles = value; }
	}
	private Stack<GameObject> topRightTiles = new Stack<GameObject>();
	public Stack<GameObject> TopRightTiles{
		get{ return topRightTiles; }
		set{ topRightTiles = value; }
	}
	private Stack<GameObject> topLeftTiles = new Stack<GameObject>();
	public Stack<GameObject> TopLeftTiles{
		get{ return topLeftTiles; }
		set{ topLeftTiles = value; }
	}
	private Stack<GameObject> bottomRightTiles = new Stack<GameObject>();
	public Stack<GameObject> BottomRightTiles{
		get{ return bottomRightTiles; }
		set{ bottomRightTiles = value; }
	}
	private Stack<GameObject> bottomLeftTiles = new Stack<GameObject>();
	public Stack<GameObject> BottomLeftTiles{
		get{ return bottomLeftTiles; }
		set{ bottomLeftTiles = value; }
	}

	public static MediumPathGenerator Instance{
		get{ 
			if (instance == null) {
				instance = GameObject.FindObjectOfType<MediumPathGenerator>();
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start () {

		createTile (20);

		for (int i = 0; i < 20; i++) {
			spawnTile ();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void createTile(int amount){
		for(int i = 0; i < amount; i++){
			topTiles.Push (Instantiate (tilePrefabs [0]));
			rightTiles.Push (Instantiate (tilePrefabs [1]));
			leftTiles.Push (Instantiate (tilePrefabs [2]));
			bottomTiles.Push (Instantiate (tilePrefabs [3]));
			centerTiles.Push (Instantiate (tilePrefabs [4]));
			topRightTiles.Push (Instantiate (tilePrefabs [5]));
			topLeftTiles.Push (Instantiate (tilePrefabs [6]));
			bottomRightTiles.Push (Instantiate (tilePrefabs [7]));
			bottomLeftTiles.Push (Instantiate (tilePrefabs [8]));
			topTiles.Peek ().name = "TopTile";
			topTiles.Peek ().SetActive (false);
			rightTiles.Peek ().name = "RightTile";
			rightTiles.Peek ().SetActive (false);
			leftTiles.Peek ().name = "LeftTile";
			leftTiles.Peek ().SetActive (false);
			bottomTiles.Peek ().name = "BottomTile";
			bottomTiles.Peek ().SetActive (false);
			centerTiles.Peek ().name = "CenterTile";
			centerTiles.Peek ().SetActive (false);
			topRightTiles.Peek ().name = "TopRightTile";
			topRightTiles.Peek ().SetActive (false);
			topLeftTiles.Peek ().name = "TopLeftTile";
			topLeftTiles.Peek ().SetActive (false);
			bottomRightTiles.Peek ().name = "BottomRightTile";
			bottomRightTiles.Peek ().SetActive (false);
			bottomLeftTiles.Peek ().name = "BottomLeftTile";
			bottomLeftTiles.Peek ().SetActive (false);
		}
	}

	public void spawnTile(){

		if (leftTiles.Count == 0 || centerTiles.Count == 0 || rightTiles.Count == 0 
			|| bottomLeftTiles.Count == 0 || bottomTiles.Count == 0 || bottomRightTiles.Count == 0 
			|| topLeftTiles.Count == 0 || topTiles.Count == 0 || topRightTiles.Count == 0) {
			createTile (10);
		}
		//generate random number
		//childCount = currentTile.transform.childCount;
		//randomIndex = Random.Range (0, childCount);
		randomChild = Random.Range (0, 4);

		if (randomIndex == 0) {
			GameObject temp = topTiles.Pop ();
			temp.SetActive (true);
			childCount = currentTile.transform.childCount;
			randomIndex = Random.Range (1, childCount);
			temp.transform.position = currentTile.transform.GetChild (randomIndex).transform.GetChild (randomChild).position;
			currentTile = temp;
			Debug.Log ("Top");
		}
		else if (randomIndex == 1) {
			GameObject temp = rightTiles.Pop ();
			temp.SetActive (true);
			childCount = currentTile.transform.childCount;
			randomIndex = Random.Range (1, childCount);
			temp.transform.position = currentTile.transform.GetChild (randomIndex).transform.GetChild (randomChild).position;
			currentTile = temp;
			Debug.Log ("Right");
		}
		else if (randomIndex == 2) {
			GameObject temp = leftTiles.Pop ();
			temp.SetActive (true);
			childCount = currentTile.transform.childCount;
			randomIndex = Random.Range (1, childCount);
			temp.transform.position = currentTile.transform.GetChild (randomIndex).transform.GetChild (randomChild).position;
			currentTile = temp;
			Debug.Log ("Left");
		}
		else if (randomIndex == 3) {
			GameObject temp = bottomTiles.Pop ();
			temp.SetActive (true);
			childCount = currentTile.transform.childCount;
			randomIndex = Random.Range (1, childCount);
			temp.transform.position = currentTile.transform.GetChild (randomIndex).transform.GetChild (randomChild).position;
			currentTile = temp;
			Debug.Log ("Bottom");
		}
		else if (randomIndex == 4) {
			GameObject temp = centerTiles.Pop ();
			temp.SetActive (true);
			childCount = currentTile.transform.childCount;
			randomIndex = Random.Range (1, childCount);
			temp.transform.position = currentTile.transform.GetChild (randomIndex).transform.GetChild (randomChild).position;
			currentTile = temp;
			Debug.Log ("Center");
		}
		else if (randomIndex == 5) {
			GameObject temp = topRightTiles.Pop ();
			temp.SetActive (true);
			childCount = currentTile.transform.childCount;
			randomIndex = Random.Range (1, childCount);
			temp.transform.position = currentTile.transform.GetChild (randomIndex).transform.GetChild (randomChild).position;
			currentTile = temp;
			Debug.Log ("Top Right");
		}
		else if (randomIndex == 6) {
			GameObject temp = topLeftTiles.Pop ();
			temp.SetActive (true);
			childCount = currentTile.transform.childCount;
			randomIndex = Random.Range (1, childCount);
			temp.transform.position = currentTile.transform.GetChild (randomIndex).transform.GetChild (randomChild).position;
			currentTile = temp;
			Debug.Log ("Top Left");
		}
		else if (randomIndex == 7) {
			GameObject temp = bottomRightTiles.Pop ();
			temp.SetActive (true);
			childCount = currentTile.transform.childCount;
			randomIndex = Random.Range (1, childCount);
			temp.transform.position = currentTile.transform.GetChild (randomIndex).transform.GetChild (randomChild).position;
			currentTile = temp;
			Debug.Log ("Bottom Right");
		}
		else if (randomIndex == 8) {
			GameObject temp = bottomLeftTiles.Pop ();
			temp.SetActive (true);
			childCount = currentTile.transform.childCount;
			randomIndex = Random.Range (1, childCount);
			temp.transform.position = currentTile.transform.GetChild (randomIndex).transform.GetChild (randomChild).position;
			currentTile = temp;
			Debug.Log ("Bottom Left");
		}

		//spawn pick up
		int spawnPickup = Random.Range (0, 25);
		if (spawnPickup == 0) {
			currentTile.transform.GetChild (0).gameObject.SetActive (true);
		}
		//instantiate prefab
		//currentTile = (GameObject)Instantiate (tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity); //to get the first child of the child of current tile
	}

	public void RestartLevel(){
		SceneManager.LoadScene ("DifficultyMedium");
		//Application.LoadLevel (Application.loadedLevel);
	}
}