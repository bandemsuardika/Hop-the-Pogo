using UnityEngine;
using System.Collections;

public class BasePlayer {

	private int life;
	private float movement;
	private float jump;
	private float luck;
	private BaseCharacterClass playerClass;
	private int currentScore;
	private int highScore;
	private int currentPoint;

	public int Life{
		get{ return life; }
		set{ life = value; }
	}
	public float Movement{
		get{ return movement; }
		set{ movement = value; }
	}
	public float Jump{
		get{ return jump; }
		set{ jump = value; }
	}
	public float Luck{
		get{ return luck; }
		set{ luck = value; }
	}
	public BaseCharacterClass PlayerClass{
		get{ return playerClass; }
		set{ playerClass = value; }
	}
	public int CurrentScore{
		get{ return currentScore; }
		set{ currentScore = value; }
	}
	public int HighScore{
		get{ return highScore; }
		set{ highScore = value; }
	}
	public int CurrentPoint{
		get{ return currentPoint; }
		set{ currentPoint = value; }
	}
}
