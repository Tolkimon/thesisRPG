using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class QuestItem : MonoBehaviour {
	
	public Flowchart flowchart;
	public string itemName;
	public string questcomplete;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (flowchart.GetBooleanVariable (questcomplete)) {
			transform.parent.gameObject.SetActive (false);

		}
			
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyUp (KeyCode.F)) {
				Debug.Log ("Hello");
				flowchart.ExecuteBlock (itemName);
			}
		}

	}
}

