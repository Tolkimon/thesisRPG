using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Animator anim;
	private Rigidbody2D myRigidBody;
	private bool playerMoving;
	public Vector2 lastMove;

	private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;
	public string startPoint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidBody = GetComponent<Rigidbody2D> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy (gameObject);
		}

	}

	// Update is called once per frame
	void Update () {
		if (!attacking) {

			// longer
			playerMoving = false;
			float movementInputX = Input.GetAxisRaw("Horizontal");
			float movementInputY = Input.GetAxisRaw("Vertical");

			Vector2 direction = new Vector2(movementInputX, movementInputY);
			direction.Normalize();
			direction *= moveSpeed * Time.deltaTime;


			if ((movementInputX != 0f && movementInputY !=0f) || (movementInputX !=0f || movementInputY != 0f))
			{
				transform.Translate(new Vector3(direction.x, direction.y, 0f));
				myRigidBody.velocity = direction;
				playerMoving = true;
				lastMove = new Vector2 (movementInputX, movementInputY);
			}    

			if (movementInputX < 0.5f && movementInputX > -0.5f)
			{
				myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
			}

			if (movementInputY < 0.5f && movementInputY > -0.5f)
			{
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
			}
			if (Input.GetKeyDown (KeyCode.J)) {
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
		anim.SetFloat("MoveX",Input.GetAxisRaw("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);	
	}
}
