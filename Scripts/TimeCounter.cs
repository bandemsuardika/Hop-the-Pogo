using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

	public Text countdownText;
	public float minutes, seconds;
	// Use this for initialization
	void Start () {
		countdownText = GetComponent<Text> () as Text;
	}
	
	// Update is called once per frame
	void Update () {
		minutes = (int)(Time.timeSinceLevelLoad / 60f);
		seconds = (int)(Time.timeSinceLevelLoad % 60f);
		//countdownText = minutes.ToString("00") + ":" + seconds.ToString("00");
	}
}
