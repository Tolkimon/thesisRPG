﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {


	public float moveSpeed;
	private Rigidbody2D myRigidbody;

	public bool isWalking;
	public float walkTime;
	public float waitTime;
	private float walkCounter;
	private float waitCounter;

	private int WalkDirection;

	public Collider2D walkZone;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;
	private bool hasWalkZone;

	public bool canMove;
	//private DialogueManager theDM;

	// Use this for initialization
	void Start () {
		//theDM = FindObjectOfType<DialogueManager> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();
		if (walkZone != null) {
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

		/*if (!theDM.dialogActive) {

			canMove = true;
		}*/

		if (!canMove) {
			myRigidbody.velocity = Vector2.zero;
			return;
		}
		if (isWalking) {
			walkCounter -= Time.deltaTime;

			switch (WalkDirection) {
			case 0: //up
				myRigidbody.velocity = new Vector2 (0, moveSpeed);
				if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;

			case 1: //right
				myRigidbody.velocity = new Vector2 (moveSpeed, 0);
				if (hasWalkZone && transform.position.x > maxWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;

			case 2: //down
				myRigidbody.velocity = new Vector2 (0, -moveSpeed);
				if (hasWalkZone && transform.position.y < minWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;

			case 3: //left
				myRigidbody.velocity = new Vector2 (-moveSpeed, 0);
				if (hasWalkZone && transform.position.x < minWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			}

			if (walkCounter < 0) {
				isWalking = false;
				waitCounter = waitTime;
			}

		}
		else {
			waitCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			if (waitCounter < 0) {
				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection(){

		WalkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;

	}



}
