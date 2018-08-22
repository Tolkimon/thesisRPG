using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class QuestItem : MonoBehaviour {
	
	public Flowchart flowchart;
	public string itemName;
	public string questcomplete;
	private PlayerController pc;
	public Button pause;
	// Use this for initialization
	void Start () {
		if (SaveGame.Exists (questcomplete)) {
			Load ();
		}
		pc = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (flowchart.GetBooleanVariable (questcomplete)) {
			transform.parent.gameObject.SetActive (false);

		}
		if (flowchart.GetBooleanVariable("End")) {


			pc.canMove = true;
			flowchart.SetBooleanVariable ("End", false);
			pause.enabled = true;
			pause.gameObject.SetActive (true);
		}
			
	}

	public void Save(){
		SaveGame.Save<bool>(questcomplete, flowchart.GetBooleanVariable (questcomplete));
		Debug.Log (flowchart.GetBooleanVariable (questcomplete));
	}

	public void Load(){
		flowchart.SetBooleanVariable (questcomplete, SaveGame.Load<bool>(questcomplete));

	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyUp (KeyCode.F)) {
				if (pause == null) {
					pause = GameObject.FindGameObjectWithTag ("Pause").GetComponent<Button> ();
				}
				flowchart.ExecuteBlock (itemName);
				pc.canMove = false;
				pause.enabled = false;
				pause.gameObject.SetActive (false);
			}
		}

	}
}

