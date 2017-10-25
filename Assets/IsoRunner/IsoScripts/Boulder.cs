using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

	public Rigidbody rb;
	bool canSpawn = true;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		if(transform.position.z <= -9.8f){
			Destroy(gameObject);        	//Mueren al llegar al limite visual

		}

		if(transform.position.z <= 2.0f && canSpawn){
			GameManagerIso.GM.Spawner ();
			canSpawn = false;
			Invoke ("spawnCd",2);
		}

		if(GameManagerIso.GM.gameOver){
			Destroy(gameObject); 
		}
	}

	void FixedUpdate() {
			rb.velocity = new Vector3(0, 0,GameManagerIso.GM.velocity );

	}

	void spawnCd(){
		canSpawn = true;
	}
}