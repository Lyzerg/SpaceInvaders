using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IJPlayerController : MonoBehaviour {

	Rigidbody rb;
	bool jump;
	[SerializeField]float addedForce; 
	[SerializeField]float num;
	[SerializeField]IJUIManager ijuiManager;
	[SerializeField]GameObject cam;
	float ripLimit = -2.25f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update(){
		//RipZone
		if(transform.position.y < ripLimit ){
			ijuiManager.GameOver ();
			cam.transform.parent = null;
			Destroy (gameObject, 1);
		}


		if(Input.GetMouseButton(0)){
			jump = false;
			addedForce += num;
		}

		if (Input.GetMouseButtonUp(0)){
			jump = true;
			ripLimit += 1.5f; 				//Raisethe "Play Area"
			Invoke ("StopForce", 0.05f);
		}

	}

	void FixedUpdate () {
		if (jump) {
			rb.AddForce (new Vector3 (0,addedForce,addedForce * 0.2f));

		}
	}

	void StopForce(){
		jump = false;
		addedForce = 0;
	}

}
