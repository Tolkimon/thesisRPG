using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

	private QuestManager theQM;
	public int questNumber;

	public bool startQuest;
	public bool endQuest;

	public BoxCollider2D dzone;
	public BoxCollider2D qzone;

	// Use this for initialization
	void Start () {
		theQM = FindObjectOfType<QuestManager> ();
		dzone.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){

		if (Input.GetKeyUp (KeyCode.F) || endQuest) {
			if (other.gameObject.name == "Player" && !theQM.questCompleted [questNumber]) {
			

				if (startQuest && !theQM.quests [questNumber].gameObject.activeSelf) {
					theQM.quests [questNumber].gameObject.SetActive (true);
					theQM.quests [questNumber].StartQuest ();
			
				}
				if (endQuest && theQM.quests [questNumber].gameObject.activeSelf) {
				
					theQM.quests [questNumber].EndQuest ();
					dzone.enabled = true;
					qzone.enabled = false;

				}
			} 

		}
	}

}
