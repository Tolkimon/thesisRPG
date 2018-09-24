using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EnemyHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;
	private PlayerStats thePlayerStats;
	public int expToGive;
	public Flowchart flowchart;

	public string enemyQuestName;


	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
		thePlayerStats = FindObjectOfType<PlayerStats> ();

	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) {
			
			Destroy (gameObject);
			thePlayerStats.AddExperience (expToGive);
			flowchart.SetIntegerVariable ("Enemies", flowchart.GetIntegerVariable ("Enemies") - 1);

		}
	}

	public void HurtEnemy(int damageToGive){
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		CurrentHealth = MaxHealth;

	}

}
