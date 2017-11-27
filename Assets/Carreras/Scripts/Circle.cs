using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

	public Rigidbody2D rb;
	bool canSpawn = true;
	float cd;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		rb.velocity = new Vector3(0, GameManagerC.GM.velocity);

		if(transform.position.y <= -6){
			GameManagerC.GM.GameOver ();					//LOL U DIED
			Destroy(gameObject);        	//Mueren al llegar al limite visual
				
		}

		if((transform.position.y <= -1) && canSpawn){
			GameManagerC.GM.Spawn ();
			canSpawn = false;
			cd = Random.Range (0.75f, 1.75f);
			Invoke ("spawnCd",5); 
		}
			
			
	}



	void spawnCd(){
		canSpawn = true;
	}


}