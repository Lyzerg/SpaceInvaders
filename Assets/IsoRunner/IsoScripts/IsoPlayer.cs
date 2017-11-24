using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPlayer : MonoBehaviour {

	[SerializeField]GameObject boom;
	Rigidbody rb;
	bool airborne;
	int z;
	[SerializeField] int dodgeSpeed;
	bool dodging;
	[SerializeField]int speed;
	[SerializeField]bool player2;

	void Start(){
		rb = GetComponent<Rigidbody> ();

	}

	void Update () {
		
		if (transform.position.x >= 5 || transform.position.x <= -5) {			 //Se sale, se muere
			//Pierde el control del imput  SI
			//Render Game over Panel 		SI
			//Stop Time Counter				NO
			GameManagerIso.GM.GameOver ();
			Instantiate (boom, transform.position, Quaternion.identity);
			Destroy (gameObject);

		}
		else{
			
			if (!player2) {
				if (Input.GetKeyDown (KeyCode.A) && !airborne) {						//poner
					StartCoroutine (ChangeLane (false));
				}
				if (Input.GetKeyDown (KeyCode.D) && !airborne) {						//poner
					StartCoroutine (ChangeLane (true));
				}


				if (Input.GetKey (KeyCode.Space) && !airborne) {

					rb.velocity = new Vector3 (0, 10, 0);
				}

			} 
			else {

				//movimiento
				if (Input.GetKeyDown (KeyCode.LeftArrow) && !airborne) {
					StartCoroutine (ChangeLane (false));
				}

				if (Input.GetKeyDown (KeyCode.RightArrow) && !airborne) {
					StartCoroutine (ChangeLane (true));
				}
					
				if (Input.GetKey (KeyCode.UpArrow) && !airborne) {

					rb.velocity = new Vector3 (0,10,0);
				}
			}
		}
		
	}

	void OnTriggerEnter(Collider other){
		GameManagerIso.GM.GameOver ();
		Instantiate (boom, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	void OnCollisionExit(Collision collision){
		if (collision.collider.tag == "Player") {
			print ("Jugador ");
		} else {
			airborne = true;
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "Player") {
			print ("Jugador ");
		} else {
			airborne = false;
		}


	}

	IEnumerator ChangeLane(bool right)
	{
		if (!dodging) {
			dodging = true;
			float currentX = transform.position.x;

			if (!right) {
				while (transform.position.x > currentX - 1) {
					transform.Translate (Vector3.left * Time.deltaTime * dodgeSpeed);
					yield return new WaitForEndOfFrame ();
				}
			} else {
				while (transform.position.x < currentX + 1) {
					transform.Translate (Vector3.right * Time.deltaTime * dodgeSpeed);
					yield return new WaitForEndOfFrame ();
				}
			}

		}
		dodging = false;
	}




}



//<>