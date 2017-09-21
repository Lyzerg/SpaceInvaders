using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float speedDown;
	[SerializeField] GameObject ray;
	bool right = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		StartCoroutine (EnemiesMovement());
		InvokeRepeating ("AddSpeed", 1, 100); //Aumento la velocidad de los enemigos "overtime"

		//Disparo para Debugg
		if(Input.GetKeyDown (KeyCode.P)){
			Instantiate (ray,transform.position, Quaternion.identity);

		}

	}

	IEnumerator EnemiesMovement(){
		yield return new WaitForSeconds (0.56f);
		if(GameManager.GM.playerLive){
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

	void AddSpeed (){
		if (GameManager.GM.playerLive) {
			speed += 0.0005f;
		}
	}


		
}
