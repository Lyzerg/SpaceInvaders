using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] GameObject bullet;
	[SerializeField][Range(0,1)] float cd = 0.5f;
	bool canShoot = true;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A) && transform.position.x > -6) {
			transform.Translate (Vector2.left * Time.deltaTime * speed);	// falta limitar al jugador en X
		}
		if (Input.GetKey (KeyCode.D) && transform.position.x < 6) {
			transform.Translate (Vector2.right * Time.deltaTime * speed);
		}
		if (Input.GetKeyDown (KeyCode.Space) && canShoot) {
			canShoot = false;
			Invoke ("shootCooldown", cd);	
			Instantiate (bullet,transform.position, Quaternion.identity);

		}


		print (canShoot);
	}

	void shootCooldown(){
		canShoot = true;
	}
}
