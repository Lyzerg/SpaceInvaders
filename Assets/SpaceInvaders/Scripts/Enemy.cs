using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject bullet;

	int idX, idY;
	int searchY;
	bool canShoot = true;
	private GameObject wea;


	// Use this for initialization
	void Start () {
		idX = GameManager.GM.x;
		idY = GameManager.GM.y;


	}
	
	// Update is called once per frame
	void Update () {
//		Shoot ();
		if(canShoot){
				canShoot = false;
				Invoke ("shootCooldown", 2.0f);
				Shoot ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			GameManager.GM.uiManager.life -= 1;
			GameManager.GM.uiManager.UpdateLife ();
			GameManager.GM.uiManager.GameOver();
			Time.timeScale = 0;
		}
	}

	void OnMouseDown(){
		for(searchY = idY-1; searchY >=0; searchY-=1){
			wea = GameObject.Find (idX +","+ searchY);		//Aqui compruebo que a partirde un objeto puedo buscar otros
			Destroy (wea);
		}
	}

	void shootCooldown(){
		canShoot = true;
	}

	void Shoot (){
		if (idY > 0) {
			for (searchY = idY - 1; searchY >= 0; searchY -= 1) { //Busco si existe alguien debajo
				wea = GameObject.Find (idX + "," + searchY);
				if (wea) {						// SI no existe, disparo
					return;
				} else {
					Instantiate (bullet, transform.position, Quaternion.identity);
					return;
				}
			}
		} 
//		else if (idY == 0) {
//			Instantiate (bullet, transform.position, Quaternion.identity);
//		}
	}
}
