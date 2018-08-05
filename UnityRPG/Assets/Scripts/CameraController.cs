using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 targetPos;
	public float moveSpeed;

	private static bool cameraExists;
	// Use this for initialization
	void Start () {
		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy (gameObject);
		}
	}

	void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode){
		/*if (scene.name == "Menu") {
			gameObject.SetActive (false);

		}else {
			transform.gameObject.SetActive (true);

		}*/
	}
	// Update is called once per frame
	void Update () {
		
		SceneManager.sceneLoaded += OnSceneLoaded;

		//get position of target
		if (followTarget != null) {
			targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
			// a= current camera position, b= current player position, t= movespeed of camera
			transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
		}
	}
}
