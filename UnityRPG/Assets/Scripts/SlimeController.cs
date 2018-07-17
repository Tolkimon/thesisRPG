using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

	public float movespeed;

	private Rigidbody2D myRigidBody;
	private bool moving;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	private GameObject thePlayer;

	private Vector3 moveDirection;

	public float waitToReload;
	private bool reloading;


	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float shootingrate=0.5f;
	private float shootcooldown;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;
		shootcooldown = 0f;
		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {


		if (shootcooldown > 0) {

			shootcooldown -= Time.deltaTime;
		}

		if (moving) {
			
			timeToMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = moveDirection;

			if (timeToMoveCounter < 0f) {

				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}

		} 
		else {

			fire ();
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = Vector2.zero;

			if (timeBetweenMoveCounter < 0f) {

				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);

				moveDirection = new Vector3 (Random.Range (-1f, 1f) * movespeed, Random.Range (-1f, 1f) * movespeed, 0f);
			}
		}

		if (reloading) {

			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				thePlayer.SetActive (true);
			}

		}

	}

	void OnCollisionEnter2D(Collision2D other){
		
		if (other.gameObject.tag == "Bullet") {
			Physics2D.IgnoreCollision(other.gameObject.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());

		}

	}

	void fire(){
		if (canAttack) {
			shootcooldown = shootingrate;
			var bullet = (GameObject)Instantiate (
				            bulletPrefab,
				            bulletSpawn.position,
				            transform.rotation);
		
			//bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6 * Time.deltaTime;
			bullet.GetComponent<Rigidbody2D> ().AddForce (bulletSpawn.forward * 450);
			Destroy (bullet, 1.5f);
		}
	}

	public bool canAttack{
		get{

			return shootcooldown <= 0f;
		}

	}

}
