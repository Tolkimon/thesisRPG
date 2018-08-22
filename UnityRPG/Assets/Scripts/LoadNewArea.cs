using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNewArea : MonoBehaviour {
	
	public string exitPoint;
	public string sceneName;
	private PlayerController thePlayer;
	public Button save;
	public Button pause;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.name == "Player") {
			if (pause == null) {
				pause = GameObject.FindGameObjectWithTag ("Pause").GetComponent<Button> ();
			}

			if (save == null) {
				pause.onClick.Invoke();
				save = GameObject.FindGameObjectWithTag ("Save").GetComponent<Button> ();
				pause.onClick.Invoke();
			}
			save.onClick.Invoke();
			SceneManager.LoadScene(sceneName);﻿
			thePlayer.startPoint = exitPoint;
		}

	}
}
