using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector2.left * Time.deltaTime * speed);	// falta limitar al jugador en X
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector2.right * Time.deltaTime * speed);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (bullet,transform.position, Quaternion.identity);			//Toca Saber la Pos del Jugador
		}
	}
}
