using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPlayer : MonoBehaviour {


	void Start(){
		
	}

	void Update () {
		if (transform.position.x > 5 && transform.position.x < -5) { //Se sale, se muere
			//Pierde el control del imput
			//Render Game over Panel
			//Stop Time Counter
		}
		else{
			if (Input.GetKeyUp (KeyCode.A)) {
				transform.position -= new Vector3 (1, 0, 0);
			}
			if (Input.GetKeyUp (KeyCode.D)) {
				transform.position += new Vector3 (1, 0, 0);
			}
		}
		
	}
}



//<>