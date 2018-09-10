using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

	public VolumeController[] vcObjects;

	public float currentVolumeLevel = 1.0f;
	public float maxVolumeLevel;

	// Use this for initialization
	void Start () {
		vcObjects = FindObjectsOfType<VolumeController> ();
		if (currentVolumeLevel > maxVolumeLevel) {
			currentVolumeLevel = maxVolumeLevel;
		}
		for (int i = 0; i < vcObjects.Length; i++) {

			vcObjects [i].SetAudioLevel (currentVolumeLevel);

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
