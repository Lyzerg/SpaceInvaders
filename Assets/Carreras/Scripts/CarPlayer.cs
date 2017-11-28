using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlayer : MonoBehaviour {

	bool dodging;
	[SerializeField] int dodgeSpeed;
	[SerializeField] bool blue;
	[SerializeField]GameObject boom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (blue) {
			if (Input.GetKeyDown (KeyCode.A) && transform.position.x >= -1.5f) {						
				StartCoroutine (ChangeLane (false));
			}
			if (Input.GetKeyDown (KeyCode.D) && transform.position.x <= -1.5f) {						
				StartCoroutine (ChangeLane (true));
			}

		} 
		else {

			//movimiento
			if (Input.GetKeyDown (KeyCode.LeftArrow) && transform.position.x >= 1.5f) {
				StartCoroutine (ChangeLane (false));
			}

			if (Input.GetKeyDown (KeyCode.RightArrow) && transform.position.x <= 1.5f) {
				StartCoroutine (ChangeLane (true));
			}
				
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (blue) {			//Jugador Azul
			if (other.gameObject.tag == "Blue") { 		//Toca Azul
				GameManagerC.GM.UpdateScore ();
				Destroy (other.gameObject);
			}
			else {			//Toca Rojo
				GameManagerC.GM.GameOver ();
				Destroy (other.gameObject);
				Instantiate (boom,transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
		}
		else {
			if (other.gameObject.tag == "Blue") { 		//Toca Azul
				GameManagerC.GM.GameOver ();
				Destroy (other.gameObject);
				Instantiate (boom,transform.position, Quaternion.identity);
				Destroy (gameObject);
			}
			else {			//Toca Rojo
				GameManagerC.GM.UpdateScore ();
				Destroy (other.gameObject);
			}
			
		}
	}

	IEnumerator ChangeLane(bool right)
	{
		if (!dodging) {
			dodging = true;
			float currentX = transform.position.x;

			if (!right) {
				while (transform.position.x >= currentX - 1.2f) {
					transform.Translate (Vector2.left * Time.deltaTime * dodgeSpeed);
					yield return new WaitForEndOfFrame ();
				}
			} else {
				while (transform.position.x <= currentX + 1.2f) {
					transform.Translate (Vector2.right * Time.deltaTime * dodgeSpeed);
					yield return new WaitForEndOfFrame ();
				}
			}

		}
		dodging = false;
	}
}
