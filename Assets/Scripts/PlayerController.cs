using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] GameObject bullet;
	[SerializeField][Range(0,1)] float cd = 0.5f;
	bool canShoot = true;
	bool canMove = false;

	// Use this for initialization
	void Start () {
		if (GameManager.GM.uiManager.life == 6) { //si es el primer spawn
			StartCoroutine (MovementLock ());
		}
		else {
			canMove = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if(canMove){
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
		}
	}

	void shootCooldown(){
		canShoot = true;
	}

	IEnumerator MovementLock(){
		yield return new WaitForSeconds (0.9f);
		canMove = true;
	}
}
