using UnityEngine;
using System.Collections;

public class BaseLuckyClass : BaseCharacterClass {

	public BaseLuckyClass(){
		CharacterClassName = "Lucky";
		CharacterClassDescription = "A character with high luck.";
		Life = 2;
		Movement = 4;
		Jump = 4;
		Luck = 5;
	}
}
