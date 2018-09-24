using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour {

	public Image img;
	public string fungusVar;
	public Flowchart flowchart;

	// Use this for initialization
	void Start () {

		img.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (flowchart != null) {
			if (flowchart.GetBooleanVariable (fungusVar)) {
				img.enabled = true;
			}

			else if (!flowchart.GetBooleanVariable (fungusVar)) {
				img.enabled = false;
			}

		}

	}


	}

