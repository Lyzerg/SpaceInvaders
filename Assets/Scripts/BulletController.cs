using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (0,1) * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			Destroy (other.gameObject);
			GameManager.GM.enemyCount -= 1;
			if(other.gameObject.name == "Enemy_A(Clone)"){ //no creo que sea lo mas optimo + 
				GameManager.GM.uiManager.score += 10;	   //hago el score publico en "UIManager"
			}
			if(other.gameObject.name == "Enemy_B(Clone)"){ 
				GameManager.GM.uiManager.score += 20;	   
			}
			if(other.gameObject.name == "Enemy_C(Clone)"){ 
				GameManager.GM.uiManager.score += 30;	   
			}
			if(other.gameObject.name == "MiniBoss(Clone)"){ 
				GameManager.GM.uiManager.score += 100;	   
			}
			GameManager.GM.uiManager.UpdateScore ();
		}
		Destroy (gameObject);
	}
}
