using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3DC : MonoBehaviour {

	public static GameManager3DC GM;

	public CollectorUI collectorUI;
	public bool win;
	public bool gameOver;

	[SerializeField]GameObject block;

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


	void Start () {
		Blocks ();
	}


	void Update () {
		
	}

	void Blocks(){
		for (int i = 0; i <= 9; i++) {
			float rndX = Random.Range (-11.8f, 11.8f);
			float rndZ = Random.Range (-11.8f, 11.8f);
			Instantiate (block, new Vector3(rndX,0.5f,rndZ),Quaternion.identity);
		}
	}
}
