using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

/*
A - B
A(0,0)
B(-10,0)

Avanza de A a B con rb.velocity

al llegar a B (transform. position) o lo destruyo o rb. vel = 0 y transform . pos = (0,0)
*/