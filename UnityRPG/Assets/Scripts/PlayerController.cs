using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree.Types;
using BayatGames.SaveGameFree;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Animator anim;
	private Rigidbody2D myRigidBody;
	private bool playerMoving;
	public Vector2 lastMove;
	private Vector2 velocity;
	private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;
	public string startPoint;
	public bool canMove;
	public GameObject startpoint;
	string name;
	Scene s;
	public string identifier = "savePosition.dat";
	private int saved;
	private SFXManager sfxMan;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		myRigidBody = GetComponent<Rigidbody2D> ();
		sfxMan = FindObjectOfType<SFXManager> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy (gameObject);
		}
		if (SaveGame.Exists("saved")) {
			Load ();
		}
		canMove = true;
		lastMove = new Vector2 (0, -1);

	}

	public void Save(){
		saved = 1;
		SaveGame.Save<int>("saved", saved);
		SaveGame.Save<Vector3Save> (identifier, transform.position);

	}

	public void Load(){
		saved = SaveGame.Load<int>("saved");
		transform.position = SaveGame.Load<Vector3Save> (identifier,Vector3.zero);

	}

	void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode){
		if (!SaveGame.Exists ("saved") && SceneManager.GetActiveScene().buildIndex - 1 == 0) {
			startpoint = GameObject.FindGameObjectWithTag ("StartPoint");
			transform.position = startpoint.transform.position;

		}
	}

	// Update is called once per frame
	void Update () {
		SceneManager.sceneLoaded += OnSceneLoaded;
		//SceneManager.sceneLoaded += OnSceneLoaded;
		if (!canMove) {

			myRigidBody.velocity = Vector2.zero;
			return;
		}

		if (!attacking) {

			playerMoving = false;
			float movementInputX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
			float movementInputY = CrossPlatformInputManager.GetAxisRaw("Vertical");

			Vector2 direction = new Vector2(movementInputX, movementInputY);
			direction.Normalize();
			direction *= moveSpeed * Time.deltaTime;
			velocity = new Vector2 (movementInputX, movementInputY);
			velocity *= moveSpeed;


			if (CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0.5f || CrossPlatformInputManager.GetAxisRaw("Horizontal") < -0.5f){      
				transform.Translate(new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));        
				playerMoving = true;      
				lastMove = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0f);   
			} 
			if (CrossPlatformInputManager.GetAxisRaw("Vertical") > 0.5f || CrossPlatformInputManager.GetAxisRaw("Vertical") < -0.5f)  {
				transform.Translate(new Vector3(0f, CrossPlatformInputManager.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f)); 
				playerMoving = true;   
				lastMove = new Vector2(0f, CrossPlatformInputManager.GetAxisRaw("Vertical"));   
			}

			if (CrossPlatformInputManager.GetButton("Shoot")) {
				attackTimeCounter = attackTime;
				attacking = true;
				myRigidBody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);
			}
		}

		if (attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("Attack", false);

		}
		//shorter
		//transform.Translate (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0)﻿;
		anim.SetFloat("MoveX",CrossPlatformInputManager.GetAxisRaw("Horizontal"));
		anim.SetFloat ("MoveY", CrossPlatformInputManager.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);

	}


}