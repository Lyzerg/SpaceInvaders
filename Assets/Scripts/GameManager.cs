using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]GameObject[] enemies;
	[SerializeField]GameObject player;
	[SerializeField]GameObject defense;
	[SerializeField]GameObject miniBoss;

	public static GameManager GM;
	public UIManager uiManager;
	public int enemyCount;
	public bool miniBossLive = false;
	int type = 2;
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
		StartCoroutine (Spawn());
		Instantiate (player);
	}

	void Update() {

		if (!miniBossLive) {
			delay = Random.Range (15f,25f);
			Invoke ("MiniBossSpawn",delay);
			miniBossLive = true;
		}
	}
		
	IEnumerator Spawn() {
		Instantiate (defense);

		for (float j = 3.5f; j >=0.6f; j-=0.7f){
			for (int i = -5; i < 6; i++) {
				GameObject enemyChild = Instantiate (enemies[type], new Vector2(i,j),Quaternion.identity); //as GameObject
				enemyChild.transform.parent = GameObject.Find ("EnemiesController").transform;
				enemyCount +=1;
				if (enemyCount == 11){
					type = 1;
				}
				if (enemyCount == 33) {
					type = 0;
				}
				yield return new WaitForSeconds (0.05f);
			}
		}
	}

	void MiniBossSpawn(){
		Instantiate (miniBoss);
	}
}