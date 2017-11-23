using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]GameObject cam;
	[SerializeField] int speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -0.5f && !GameManager3DC.GM.win) {
		//GameOver
			cam.transform.parent = null;
			GameManager3DC.GM.collectorUI.Loose();
		}
	}
	void FixedUpdate () {
		//Movimiento con addForce
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		rb.AddForce (movement * speed);
		
		//Movimiento normal
//		if (!GameManager3DC.GM.gameOver) {
//			if (Input.GetKey (KeyCode.A) && transform.position.x > -11.7f) {
//				transform.Translate (Vector3.left * Time.deltaTime * speed);	
//			}
//			if (Input.GetKey (KeyCode.D) && transform.position.x < 11.7f) {
//				transform.Translate (Vector3.right * Time.deltaTime * speed);
//			}
//			if (Input.GetKey (KeyCode.W) && transform.position.z < 11.7f) {
//				transform.Translate (Vector3.forward * Time.deltaTime * speed);	
//			}
//			if (Input.GetKey (KeyCode.S) && transform.position.z > -11.7f ) {
//				transform.Translate (Vector3.back * Time.deltaTime * speed);
//			}
//		}

	}

	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
		GameManager3DC.GM.collectorUI.UpdateScore ();
	}
}


