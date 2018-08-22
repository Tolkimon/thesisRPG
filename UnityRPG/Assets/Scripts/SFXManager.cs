using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

	public AudioSource playerHurt;
	private static bool sfxexists;
	// Use this for initialization
	void Start () {

		if (!sfxexists) {
			sfxexists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy (gameObject);
		}
	}


}
