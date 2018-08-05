using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class Menu : MonoBehaviour {
	string name;
	Scene s;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

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
