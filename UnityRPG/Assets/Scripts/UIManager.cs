using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public PlayerHealthManager playerHealth;
	private static bool UIExists;
	private PlayerStats thePS;
	public Text levelText;

	// Use this for initialization
	void Start () {
		if (!UIExists) {
			UIExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy (gameObject);
		}
		thePS = GetComponent<PlayerStats> ();
	}
	void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode){
		/*if (scene.name == "Menu") {
			gameObject.SetActive (false);

		}else {
			transform.gameObject.SetActive (true);

		}*/
	}
	// Update is called once per frame
	void Update () {
		SceneManager.sceneLoaded += OnSceneLoaded;
		if (playerHealth != null) {
			healthBar.maxValue = playerHealth.playerMaxHealth;
			healthBar.value = playerHealth.playerCurrentHealth;
			HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
			levelText.text = "Lvl: " + thePS.currentLevel;
		}
	}
}
