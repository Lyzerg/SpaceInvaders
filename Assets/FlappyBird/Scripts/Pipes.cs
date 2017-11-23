using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour {

	Rigidbody2D rb;
	[SerializeField] float velocity;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		if(transform.position.x <= -5){
			Destroy(gameObject);        	//Mueren al llegar al limite visual

		}
			
	}

	void FixedUpdate() {
		if (GameManagerF.GM.gameOver) {
			rb.velocity = new Vector2 (0, 0);
		} else {
			rb.velocity = new Vector2 (velocity, 0);
		}

	}


}