using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	string name;
	Scene s;
	public Button load;
	public GameObject mobile;
	//public GameObject player;
	// Use this for initialization
	void Start () {
		if (SaveGame.Exists ("lvl") && load != null) {

			load.interactable = true;
		} 
		else if(load != null){

			load.interactable = false;
		}
	}

	void Awake(){
		Input.backButtonLeavesApp = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		//player = GameObject.FindGameObjectWithTag("Player"); 
	}

	public void Play(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		Time.timeScale = 1;
	
		//SceneManager.LoadScene (SaveGame.Load<string>("scene"));

	}

	public void Quit(){
		Application.Quit ();

	}

	public void BackToMenu(){
		
		SceneManager.LoadScene ("Menu");
	}

	public void newGame(){
		SaveGame.DeleteAll ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
		
}
