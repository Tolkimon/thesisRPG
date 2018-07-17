using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(360 * Time.deltaTime,360 * Time.deltaTime, 0));
		//transform.RotateAround(transform.parent.position, transform.parent.up, 360 * Time.deltaTime);
	}
}
