using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerF : MonoBehaviour {

	public static GameManagerF GM;

	public bool gameOver;
	public bool play;
	public UIF uif;
	bool canSpawn = true;
	[SerializeField]GameObject lower;
	[SerializeField]GameObject upper;
	[SerializeField]GameObject pipe;
	float timer;

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
		if(play){
			if(canSpawn){
				Spawner ();
				canSpawn = false;
				Invoke ("spawnCd",timer);
			}

			print (timer);
		}
	}

	void Spawner(){
		if(!gameOver){
			float rndY = Random.Range (-5.5f, -1);
			float rndY2 = Random.Range (8f, 9f);
			Instantiate (lower, new Vector3(5 ,rndY,0), Quaternion.identity);
			Instantiate (upper, new Vector3(5, rndY + rndY2, 0), Quaternion.identity);
			Instantiate (pipe, new Vector3(5, rndY + 4.25f, 0), Quaternion.identity);
			timer = Random.Range (2.5f,4.5f);
		}
	}

	void spawnCd(){
		canSpawn = true;
	}
}





