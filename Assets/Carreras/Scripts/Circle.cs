using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

	public Rigidbody2D rb;
	[SerializeField]bool blue;
	bool canSpawn = true;
	float cd;
	[SerializeField]GameObject boom;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		rb.velocity = new Vector3 (0, GameManagerC.GM.velocity);

//		if(transform.position.y <= -6){
//			GameManagerC.GM.GameOver ();					//LOL U DIED
//			Destroy(gameObject);        	//Mueren al llegar al limite visual
//				
//		}

		if(GameManagerC.GM.uDied){
			Destroy(gameObject);
		}

		if ((transform.position.y <= -1) && canSpawn) {
			GameManagerC.GM.Spawn ();
			canSpawn = false;
			cd = Random.Range (0.75f, 1.75f);
			Invoke ("spawnCd", 5); 
		}

		if (blue) {
			if (transform.position.y <= -6 && transform.position.x <= 0) {
				GameManagerC.GM.GameOver ();					//LOL U DIED
				Instantiate (boom,transform.position, Quaternion.identity);
				Destroy(gameObject);        	//Mueren al llegar al limite visual
			} 
			else if(transform.position.y <= -6){
				Destroy(gameObject);
			}
		}
		else { //rojo
			if (transform.position.y <= -6 && transform.position.x >= 0) {
				GameManagerC.GM.GameOver ();					//LOL U DIED
				Instantiate (boom,transform.position, Quaternion.identity);
				Destroy(gameObject);        	//Mueren al llegar al limite visual
			} 
			else if(transform.position.y <= -6){
				Destroy(gameObject);
			}
		}
			
			
	}

	void spawnCd(){
		canSpawn = true;
	}


}