using UnityEngine;
using System.Collections;

public class BaseRobustClass : BaseCharacterClass {

	public BaseRobustClass(){
		CharacterClassName = "Robust";
		CharacterClassDescription = "A character with tough body.";
		Life = 5;
		Movement = 4;
		Jump = 4;
		Luck = 2;
	}
}
