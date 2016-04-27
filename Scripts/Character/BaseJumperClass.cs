using UnityEngine;
using System.Collections;

public class BaseJumperClass : BaseCharacterClass {

	public BaseJumperClass(){
		CharacterClassName = "Jumper";
		CharacterClassDescription = "A character a high jump ability.";
		Life = 4;
		Movement = 3;
		Jump = 5;
		Luck = 3;
	}
}
