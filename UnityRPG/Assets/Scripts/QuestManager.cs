using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	//public QuestObject[] quests;
	public List<QuestObject> quests = new List<QuestObject>();
	public bool[] questCompleted;
	private bool dialogDone=false;
	public DialogueManager theDM;

	public string itemCollected;
	public string enemyKilled;
	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		questCompleted = new bool[quests.Count];
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ShowQuestText(List<string> questText){
		//for list
		//theDM.dialogLines.Clear();

		theDM.dialogLines = questText;

		

		theDM.currentLine = 0;

		//theDM.dialogLines.Add(questText[0]);

		//for array
		//theDM.dialogLines = new string[1];
		//theDM.dialogLines [0] = questText;

		//theDM.currentLine = 0;
		theDM.ShowDialogue ();
	}

}
