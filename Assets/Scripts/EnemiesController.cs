using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float speedDown;
	[SerializeField] GameObject[] weapon;
	[SerializeField] GameObject ray;
	int activeWeapon;
	bool canShoot = true;
	bool right = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Enemies Movement
		if (transform.position.x < 1.08f && right) {
			transform.Translate (Vector2.right * Time.deltaTime * speed);
		}
		if (transform.position.x > -1.08f && !right) {
			transform.Translate (Vector2.left * Time.deltaTime * speed);
		}
		if (transform.position.x >= 1.08f) {
			right = false;
			transform.Translate (Vector2.down * Time.deltaTime * speedDown);
		}
		if (transform.position.x <= -1.08f) {
			right = true;
			transform.Translate (Vector2.down * Time.deltaTime * speedDown);
		}

		//Shooting Cycle
		if(canShoot){
			Invoke ("Shoot",1.5f);
			canShoot = false;
		}

	}

	void Shoot(){
		activeWeapon = Random.Range (0,10);
		Instantiate (ray,weapon[activeWeapon].transform.position, Quaternion.identity);
		canShoot = true;
	}
}