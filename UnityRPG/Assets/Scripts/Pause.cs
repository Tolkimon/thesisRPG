using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour {

	private PlayerController pc;
	public GameObject panel;
	public Text pauseText;
	private MusicController theMC;
	private MobileDontDestroyOnLoad mobile;

	void Start () {
		pc = FindObjectOfType<PlayerController> ();
		theMC = FindObjectOfType<MusicController> ();
		mobile = FindObjectOfType<MobileDontDestroyOnLoad> ();

	}


	public void pause () {
		if (Time.timeScale == 1) {
			panel.SetActive (true);
			Time.timeScale = 0;
			pc.canMove = false;
			pauseText.text = "Resume";
			theMC.musicCanPlay = false;
			mobile.EnableControlRig (false);

		} 
		else {

			Time.timeScale = 1;
			pc.canMove = true;
			panel.SetActive (false);
			pauseText.text = "Pause";
			theMC.musicCanPlay = true;
			mobile.EnableControlRig (true);
		}
	}
}
