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
//			print ("Player");
			Destroy (other.gameObject);
			Destroy (gameObject);
			GameManager.GM.uiManager.life -= 1;
			GameManager.GM.uiManager.UpdateLife ();
			GameManager.GM.playerLive = false;

									
		} 
		if(other.tag == "Enemy_A" || other.tag == "Enemy_B" || other.tag == "Enemy_C"){
			
		}
		else if (other.tag == "Struct") {
//			print ("Struct");
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		else {
			Destroy (gameObject);
//			print ("WTF || Border");
		}
	}
}
