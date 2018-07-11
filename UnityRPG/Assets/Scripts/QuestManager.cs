using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	//public QuestObject[] quests;
	public List<QuestObject> quests = new List<QuestObject>();
	public bool[] questCompleted;

	public DialogueManager theDM;

	public string itemCollected;
	public string enemyKilled;

	// Use this for initialization
	void Start () {
		questCompleted = new bool[quests.Count];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ShowQuestText(string questText){
		//for list
		theDM.dialogLines.Clear();
		theDM.dialogLines.Add(questText);

		//for array
		//theDM.dialogLines = new string[1];
		//theDM.dialogLines [0] = questText;

		theDM.currentLine = 0;
		theDM.ShowDialogue ();
	}

}
