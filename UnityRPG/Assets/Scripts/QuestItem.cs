using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class QuestItem : MonoBehaviour {
	
	public Flowchart flowchart;
	public string itemName;
	public string questcomplete;
	private PlayerController pc;
	// Use this for initialization
	void Start () {
		pc = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (flowchart.GetBooleanVariable (questcomplete)) {
			transform.parent.gameObject.SetActive (false);

		}
		if (flowchart.GetBooleanVariable("End")) {


			pc.canMove = true;

		}
			
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyUp (KeyCode.F)) {
				
				flowchart.ExecuteBlock (itemName);
				pc.canMove = false;
			}
		}

	}
}

