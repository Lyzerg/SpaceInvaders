using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour {

	Rigidbody2D rb;
	[SerializeField]GameObject rip;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			GameManagerF.GM.uif.Play ();
			GameManagerF.GM.play = true;
			rb.gravityScale = 1;
		}

		if(GameManagerF.GM.play){
			if(transform.position.y < 4 ){
				if (Input.GetMouseButton(0)) {

					rb.velocity = new Vector2 (0, 4);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Trigger") {
			GameManagerF.GM.uif.UpdateScore ();
		} 
		else{
			Instantiate (rip, transform.position, Quaternion.identity);
			GameManagerF.GM.uif.GameOver ();
			GameManagerF.GM.gameOver = true;
			Destroy (gameObject);
		}

	}
}
