using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowchartManager : MonoBehaviour {
	public Flowchart flowchart;
	public int NPCnum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.name == "Player") {

			if (Input.GetKeyUp(KeyCode.F)) {
				Debug.Log ("Hello");
				flowchart.SetIntegerVariable ("NPC", NPCnum);
				flowchart.ExecuteBlock ("Start");
				if (transform.parent.GetComponent<VillagerMovement> () != null) {

					transform.parent.GetComponent<VillagerMovement> ().canMove = false;

				}
			}

		}
	}
}
