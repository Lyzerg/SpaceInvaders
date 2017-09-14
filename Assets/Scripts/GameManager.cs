using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]GameObject[] enemies;
	[SerializeField]GameObject defense;
	[SerializeField]GameObject miniBoss;

	public static GameManager GM;
	public UIManager uiManager;
	public int enemyCount;
	public bool miniBossLive = false;
	int type;
	float delay;

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

	void Start() {
//		Spawn ();
	}

	void Update() {

		if (!miniBossLive) {
			delay = Random.Range (15f,25f);
			Invoke ("MiniBossSpawn",delay);
			miniBossLive = true;
		}
	}
		
	void Spawn() {
		Instantiate (defense);

		for (float j = 0.7f; j <=3.5f; j+=0.7f){
			for (int i = -5; i < 6; i++) {
				GameObject enemyChild = Instantiate (enemies[type], new Vector2(i,j),Quaternion.identity); //as GameObject
				enemyChild.transform.parent = GameObject.Find ("EnemiesController").transform;
				enemyCount +=1;
				if (enemyCount == 22){
					type = 1;
				}
				if (enemyCount == 44) {
					type = 2;
				}
			}
		}
	}

	void MiniBossSpawn(){
		Instantiate (miniBoss);
	}
}