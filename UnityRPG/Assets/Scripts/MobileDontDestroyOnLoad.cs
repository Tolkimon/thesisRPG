using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileDontDestroyOnLoad : MonoBehaviour {

	public static bool exists;
	// Use this for initialization
	void Start () {
		if (!exists) {
			exists = true;
			DontDestroyOnLoad (transform.gameObject);

		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
