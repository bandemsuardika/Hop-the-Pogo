using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour {

	public GameObject currentTile;
	public GameObject[] tilePrefabs;

	private static TileManager instance;
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

	private Stack<GameObject> trap1 = new Stack<GameObject>();
	public Stack<GameObject> Trap1{
		get{ return trap1; }
		set{ trap1 = value; }
	}
	private Stack<GameObject> trap2 = new Stack<GameObject>();
	public Stack<GameObject> Trap2{
		get{ return trap2; }
		set{ trap2 = value; }
	}
	private Stack<GameObject> trap3 = new Stack<GameObject>();
	public Stack<GameObject> Trap3{
		get{ return trap3; }
		set{ trap3 = value; }
	}

	public static TileManager Instance{
		get { 
			if (instance == null) {
				instance = GameObject.FindObjectOfType<TileManager>();
			}
			return instance; 
		}
	}

	// Use this for initialization
	void Start () {

		createTile (30);

		for (int i = 0; i < 50; i++) {
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
			topTiles.Peek ().name = "TopTile";
			topTiles.Peek ().SetActive (false);
			rightTiles.Peek ().name = "RightTile";
			rightTiles.Peek ().SetActive (false);
			leftTiles.Peek ().name = "LeftTile";
			leftTiles.Peek ().SetActive (false);
			bottomTiles.Peek ().name = "BottomTile";
			bottomTiles.Peek ().SetActive (false);
			trap1.Push (Instantiate (tilePrefabs [0]));
			trap2.Push (Instantiate (tilePrefabs [1]));
			trap3.Push (Instantiate (tilePrefabs [2]));
			trap1.Peek ().name = "Trap 1";
			trap1.Peek ().SetActive (false);
			trap2.Peek ().name = "Trap 2";
			trap2.Peek ().SetActive (false);
			trap3.Peek ().name = "Trap 3";
			trap3.Peek ().SetActive (false);
		}
	}

	public void spawnTile(){

		if (leftTiles.Count == 0 || topTiles.Count == 0 || rightTiles.Count == 0) {
			createTile (20);
		}
		//generate random number
		int randomIndex = Random.Range (0, 7);

		if (randomIndex == 0) {
			GameObject temp = topTiles.Pop ();
			temp.SetActive (true);
			temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = temp;
		}
		else if (randomIndex == 1) {
			GameObject temp = rightTiles.Pop ();
			temp.SetActive (true);
			temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = temp;
		}
		else if (randomIndex == 2) {
			GameObject temp = leftTiles.Pop ();
			temp.SetActive (true);
			temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = temp;
		}
		else if (randomIndex == 3) {
			GameObject temp = bottomTiles.Pop ();
			temp.SetActive (true);
			temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = temp;
		}

		else if (randomIndex == 4) {
			GameObject temp = trap1.Pop ();
			temp.SetActive (true);
			temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = temp;
		} else if (randomIndex == 5) {
			GameObject temp = trap2.Pop ();
			temp.SetActive (true);
			temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = temp;
		} else if (randomIndex == 6) {
			GameObject temp = trap3.Pop ();
			temp.SetActive (true);
			temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = temp;
		}
		//instantiate prefab
			//currentTile = (GameObject)Instantiate (tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity); //to get the first child of the child of current tile

		//spawn pick up
		int spawnPickup = Random.Range (0, 10);
		if (spawnPickup == 0) {
			currentTile.transform.GetChild (1).gameObject.SetActive (true);
		}
	}

	public void RestartLevel(){
		SceneManager.LoadScene ("DifficultyEasy");
		//Application.LoadLevel (Application.loadedLevel);
	}
}
