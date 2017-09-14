using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour {

	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (0,-1) * speed;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			Destroy (gameObject);
									//You Loose, bajar vida
		} 
		if(other.tag == "Bullet"){
			Destroy (other.gameObject);
		}
		if(other.tag == "Enemy" || other.tag == "Weapon"){
			 //no hace nada, evito "FriendlyFire"
		}
		else {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
