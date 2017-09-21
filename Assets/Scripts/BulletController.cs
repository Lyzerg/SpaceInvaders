using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	[SerializeField] float speed;
	int weaponPosition;


	// Use this for initialization
	void Start () {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (0,1) * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		
			if(other.gameObject.tag == "Enemy_A"){ //no creo que sea lo mas optimo + 
				Destroy(other.gameObject);
				GameManager.GM.uiManager.score += 10;	   //hago el score publico en "UIManager"
				GameManager.GM.enemyCount-=1;
			}
			if(other.gameObject.tag == "Enemy_B"){ 
				Destroy(other.gameObject);
				GameManager.GM.uiManager.score += 20;	
				GameManager.GM.enemyCount-=1;
			}
			if(other.gameObject.tag == "Enemy_C"){ 
				Destroy(other.gameObject);	
				GameManager.GM.uiManager.score += 30;	
				GameManager.GM.enemyCount-=1;
			}
			if(other.gameObject.tag == "MiniBoss"){ 
				Destroy(other.gameObject);
				GameManager.GM.uiManager.score += 100;	
				GameManager.GM.miniBossLive = false;
			}
		GameManager.GM.uiManager.UpdateScore ();
		Destroy (gameObject);
	}
		
}

//if(other.tag == "Weapon"){
//
//}