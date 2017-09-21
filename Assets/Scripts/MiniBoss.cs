using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour {

	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (-1,0) * speed;
		transform.position = new Vector2 (8.5f,3.85f);
	}

	// Update is called once per frame
	void Update () {
		if(transform.position == new Vector3 (-8f,3.85f,0)){ //Llega al limite de su pos X
			Destroy(gameObject);
			GameManager.GM.miniBossLive = false;
		}
			
	}
}