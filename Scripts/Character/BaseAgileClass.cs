using UnityEngine;
using System.Collections;

public class BaseAgileClass : BaseCharacterClass {

	public BaseAgileClass(){
		CharacterClassName = "Agile";
		CharacterClassDescription = "A very agile character, high movement speed.";
		Life = 3;
		Movement = 5;
		Jump = 3;
		Luck = 4;
	}
}
