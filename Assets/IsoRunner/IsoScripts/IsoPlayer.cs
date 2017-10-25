using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPlayer : MonoBehaviour {

	Rigidbody rb;
	bool airborne;

	void Start(){
		rb = GetComponent<Rigidbody> ();

	}

	void Update () {
		print (airborne);

		if (transform.position.x >= 5 || transform.position.x <= -5) { //Se sale, se muere
			//Pierde el control del imput  SI
			//Render Game over Panel 		SI
			//Stop Time Counter				NO
			GameManagerIso.GM.GameOver ();
			Destroy (gameObject);

		}
		else{
			if (Input.GetKeyUp (KeyCode.A) && !airborne) {
				transform.position -= new Vector3 (1, 0, 0);
			}
			if (Input.GetKeyUp (KeyCode.D) && !airborne) {
				transform.position += new Vector3 (1, 0, 0);
			}
			if (Input.GetKeyDown (KeyCode.Space) && !airborne) {
				
				rb.velocity = new Vector3 (0,10,0);
//				rb.position = Vector3.up;
			}
		}
		
	}

	void OnTriggerEnter(Collider other){
		GameManagerIso.GM.GameOver ();
		Destroy (gameObject);
	}

	void OnCollisionExit(){
		airborne = true;
	}

	void OnCollisionEnter(){
		airborne = false;;
	}


}



//<>