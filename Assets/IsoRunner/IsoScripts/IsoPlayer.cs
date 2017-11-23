using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPlayer : MonoBehaviour {

	[SerializeField]GameObject boom;
	Rigidbody rb;
	bool airborne;
	int z;
	[SerializeField]int speed;
	[SerializeField]bool player2;

	void Start(){
		rb = GetComponent<Rigidbody> ();

	}

	void Update () {
		

		print (airborne);

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
					transform.position -= new Vector3 (1, 0, 0);
				}
				if (Input.GetKeyDown (KeyCode.D) && !airborne) {						//poner
					transform.position += new Vector3 (1, 0, 0);
				}


				if (Input.GetKey (KeyCode.Space) && !airborne) {

					rb.velocity = new Vector3 (0, 10, 0);
				}

			} 
			else {
				if (Input.GetKeyDown (KeyCode.LeftArrow) && !airborne) {						//poner
					transform.position -= new Vector3 (1, 0, 0);
				}
				if (Input.GetKeyDown (KeyCode.RightArrow) && !airborne) {						//poner
					transform.position += new Vector3 (1, 0, 0);
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




}



//<>