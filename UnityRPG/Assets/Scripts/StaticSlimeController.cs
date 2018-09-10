using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSlimeController : MonoBehaviour {
	public GameObject bulletPrefab;

	public float shootingrate=1f;
	private float shootcooldown;
	// Use this for initialization
	void Start () {
		
	}

	void Update () {

		if (shootcooldown > 0) {

			shootcooldown -= Time.deltaTime;
		}
		fire ();
	}

	void fire(){
		if (canAttack) {
			shootcooldown = shootingrate;
			var bullet = (GameObject)Instantiate (
				bulletPrefab,
				transform.position,
				transform.rotation);
			Physics2D.IgnoreCollision(bullet.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());
			bullet.GetComponent<Rigidbody2D> ().AddForce (transform.right * 350f);
			Destroy (bullet, 1f);
		}
	}

	public bool canAttack{
		get{

			return shootcooldown <= 0f;
		}

	}
}
