using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree.Types;
using BayatGames.SaveGameFree;

public class SceneChanger : MonoBehaviour {

	public static SceneChanger Instance;
	public GameObject mobile;
	// Use this for initialization
	void Awake ()   
	{

		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	
	}

	void Start () {
		DontDestroyOnLoad(gameObject);
		if (SaveGame.Exists ("scene")) {
			if (SaveGame.Load<string> ("scene") != "UnityRPG") {

				SceneManager.LoadScene (SaveGame.Load<string> ("scene"));
			}
		}

	}
	
	void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode){
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			/*if (mobile == null) {
				mobile = GameObject.FindGameObjectWithTag ("MobileController");
			}
			mobile.SetActive (false);*/

			//Destroy (gameObject);
			GameObject[] allObjects = GameObject.FindGameObjectsWithTag("SceneChanger");
			foreach(GameObject obj in allObjects) {
				Destroy(obj);
			}

		} 

	}
	// Update is called once per frame
	void Update () {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
}
