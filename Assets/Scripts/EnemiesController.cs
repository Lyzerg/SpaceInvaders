using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float speedDown;
	[SerializeField] GameObject ray;
	int activeWeapon;
	bool right = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		StartCoroutine (EnemiesMoement());

	}

	IEnumerator EnemiesMoement(){
		yield return new WaitForSeconds (2.8f);
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
	}
		
}