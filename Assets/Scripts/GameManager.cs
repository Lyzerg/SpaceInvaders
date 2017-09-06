using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]GameObject enemy;

	public static GameManager GM;

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
				Instantiate (enemy, new Vector2(i,j),Quaternion.identity);	
			}
		}
			
			
	}
}