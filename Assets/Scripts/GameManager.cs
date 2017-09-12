using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]GameObject[] enemies;

	public static GameManager GM;
	public int enemyCount;

	int type;

	void Awake()
	{
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

	void Start(){
		Spawn ();
	}
		
	void Spawn()
	{
		for (int j = 0; j <5; j++){
			for (int i = -5; i < 6; i++) {
				Instantiate (enemies[type], new Vector2(i,j),Quaternion.identity);
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
}