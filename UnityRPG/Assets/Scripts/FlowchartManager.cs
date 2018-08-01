using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class FlowchartManager : MonoBehaviour {
	public Flowchart flowchart;
	public int NPCnum;
	private PlayerController pc;
	public Button pause;
	// Use this for initialization
	void Start () {
		pc = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (flowchart.GetBooleanVariable("End")) {

			transform.parent.GetComponent<VillagerMovement> ().canMove = true;
			pc.canMove = true;
			flowchart.SetBooleanVariable ("End", false);
			pause.enabled = true;
			pause.gameObject.SetActive (true);
		}
	}

	void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.name == "Player") {

			if (Input.GetKeyUp(KeyCode.F)) {
				
				flowchart.SetIntegerVariable ("NPC", NPCnum);
				flowchart.ExecuteBlock ("Start");
				pause.enabled = false;
				pause.gameObject.SetActive (false);
				if (transform.parent.GetComponent<VillagerMovement> () != null) {

					transform.parent.GetComponent<VillagerMovement> ().canMove = false;
					pc.canMove = false;
				}
			}

		}
	}
}
