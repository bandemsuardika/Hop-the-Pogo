using UnityEngine;
using System.Collections;

public class BaseCharacterClass {

	private string characterClassName;
	private string characterClassDescription;

	private int life;
	private float movement;
	private float jump;
	private float luck;

	public string CharacterClassName{
		get{ return characterClassName; }
		set{ characterClassName = value; }
	}
	public string CharacterClassDescription{
		get{ return characterClassDescription; }
		set{ characterClassDescription = value; }
	}
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
}