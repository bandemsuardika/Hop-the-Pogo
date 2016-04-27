using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseTrap {
	private string trapName;
	private string trapDescription;
	private int trapID;
	private int trapEffect;

	public string TrapName{
		get { return trapName; }
		set{ trapName = value; }
	}
	public string TrapDescription{
		get { return trapDescription; }
		set{ trapDescription = value; }
	}
	public int TrapID{
		get { return trapID; }
		set{ trapID = value; }
	}
	public int TrapEffect{
		get { return trapEffect; }
		set{ trapEffect = value; }
	}
}
