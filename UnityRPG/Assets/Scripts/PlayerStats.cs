﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

	public int currentLevel;
	public int currentExp;

	public int[] toLevelUp;

	public int[] HPLevels;
	public int[] attackLevels;
	public int[] defenseLevels;

	public int currentHP;
	public int currentAttack;
	public int currentDefense;

	private PlayerHealthManager thePlayerHealth;

	// Use this for initialization
	void Start () {

		if (SaveGame.Exists ("lvl")) {
			Load ();
		} 
		else {
			currentHP = HPLevels [1];
			currentAttack = attackLevels [1];
			currentDefense = defenseLevels [1];
		}
		thePlayerHealth = FindObjectOfType<PlayerHealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		SceneManager.sceneLoaded += OnSceneLoaded;
		if (currentExp >= toLevelUp[currentLevel]) {
			//currentLevel++;
			LevelUp();
		}
	}

	void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode){
		if (!SaveGame.Exists("lvl")) {
			currentHP = HPLevels [1];
			currentAttack = attackLevels [1];
			currentDefense = defenseLevels [1];
			currentLevel = 1;
			currentExp = 0;
		}

	}

	public void Save(){

		SaveGame.Save<int>("lvl", currentLevel);
		SaveGame.Save<int>("xp", currentExp);
	}

	public void Load(){
		currentLevel = SaveGame.Load<int>("lvl");
		currentExp = SaveGame.Load<int>("xp");
		currentHP = HPLevels [currentLevel];
		currentAttack = attackLevels [currentLevel];
		currentDefense = defenseLevels [currentLevel];

	}

	public void AddExperience(int experienceToAdd){
		currentExp += experienceToAdd;
	}

	public void LevelUp(){

		currentLevel++;
		currentHP = HPLevels [currentLevel];
		thePlayerHealth.playerMaxHealth = currentHP;
		thePlayerHealth.playerCurrentHealth += currentHP - HPLevels [currentLevel - 1];

		currentAttack = attackLevels [currentLevel];
		currentDefense = defenseLevels [currentLevel];

	}
}
