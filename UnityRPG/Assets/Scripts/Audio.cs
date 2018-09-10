using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
	public static bool aExists;
	// Use this for initialization
	void Start () {
		if (!aExists) {
			aExists = true;
			DontDestroyOnLoad (transform.gameObject);

		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
