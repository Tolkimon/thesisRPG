using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree.Types;
using BayatGames.SaveGameFree;

public class SceneSave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void Save(){

		SaveGame.Save<string>("scene", SceneManager.GetActiveScene().name);

	}
	// Update is called once per frame
	void Update () {
		
	}
}
