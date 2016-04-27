using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrapManager : MonoBehaviour {

	public GameObject currentTile;
	public GameObject[] trapPrefabs;

	private static TrapManager instance;
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

	public static TrapManager Instance{
		get { 
			if (instance == null) {
				instance = GameObject.FindObjectOfType<TrapManager>();
			}
			return instance; 
		}
	}

	// Use this for initialization
	void Start () {
		createTrap (50);

		for (int i = 0; i < 50; i++) {
			spawnTrap ();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void createTrap(int amount){
		for(int i = 0; i < amount; i++){
			trap1.Push (Instantiate (trapPrefabs [0]));
			trap2.Push (Instantiate (trapPrefabs [1]));
			trap3.Push (Instantiate (trapPrefabs [2]));
			trap1.Peek ().name = "Trap 1";
			trap1.Peek ().SetActive (false);
			trap2.Peek ().name = "Trap 2";
			trap2.Peek ().SetActive (false);
			trap3.Peek ().name = "Trap 3";
			trap3.Peek ().SetActive (false);
		}
	}

	public void spawnTrap(){

		if (trap1.Count == 0 || trap2.Count == 0 || trap3.Count == 0) {
			createTrap (10);
		}
		if (Physics.CheckSphere (currentTile.transform.position, 10)) {
			//generate random number
			int randomIndex = Random.Range (0, 4);

			if (randomIndex == 0) {
				GameObject temp = trap1.Pop ();
				temp.SetActive (true);
				temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
				currentTile = temp;
			} else if (randomIndex == 1) {
				GameObject temp = trap2.Pop ();
				temp.SetActive (true);
				temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
				currentTile = temp;
			} else if (randomIndex == 2) {
				GameObject temp = trap3.Pop ();
				temp.SetActive (true);
				temp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
				currentTile = temp;
			}
		}
	}
}
