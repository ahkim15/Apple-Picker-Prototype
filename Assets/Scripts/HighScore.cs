using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour
{
	static public int score = 1000;	

	void  Awake ()	//remember that Awake method always occur before Start method
	{
		// if the ApplePickerHighScore already exists, read it
		if (PlayerPrefs.HasKey("ApplePickerHighScore"))
		{  	
			score = PlayerPrefs.GetInt("ApplePickerHighScore");
		}
		// assign the high score to ApplePickerHighScore
		PlayerPrefs.SetInt("ApplePickerHighScore", score);
	}

	void Update ()
	{
		GUIText gt = this.GetComponent<GUIText> ();
		gt.text = "High Score: " + score;

		// update ApplePickerHighScore in PlayerPrefs if necessary
		// checks every frame to see whether the current HighScore is higher than the one stored by PlayerPrefs & updates
		if (score > PlayerPrefs.GetInt ("ApplePickerHighScore"))
		{
			PlayerPrefs.SetInt ("ApplePickerHighScore", score);
		}
	}
}
