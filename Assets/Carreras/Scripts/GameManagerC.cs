using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerC : MonoBehaviour {

	public static GameManagerC GM;

	void Awake() {
		if (GM == null)
		{
			GM = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}