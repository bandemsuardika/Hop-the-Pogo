using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public float score = 0.0f;
	public Text scoreText;

	private int difficultyLevel = 1;
	private int maxDifficultyLevel = 10;
	private int scoreToNextLevel = 15;

	private bool isDead = false;

	public DeathMenu deathMenu;

	// Use this for initialization
	void Start () {
		scoreText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		if (isDead)
			return;
		
		if (score >= scoreToNextLevel) {
			LevelUp ();
		}

		score += Time.deltaTime * difficultyLevel;
		scoreText.text = ((int)score).ToString();
	}

	void LevelUp(){
		if (difficultyLevel == maxDifficultyLevel)
			return;
		
		scoreToNextLevel *= 2;
		difficultyLevel++;

		GetComponent<PlayerMotor> ().SetSpeed (difficultyLevel);
		Debug.Log (difficultyLevel);
	}

	public void onDeath(){
		isDead = true;
		PlayerPrefs.SetFloat ("Highscore",score);
		PlayerPrefs.GetFloat ("Highscore",score);
		deathMenu.ToggleEndMenu (score);
	}
}
