using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerC : MonoBehaviour {

	public static GameManagerC GM;

//	[SerializeField]UIC uic;
	[SerializeField]Text scoreUI;
	[SerializeField]Text gameOverText;
	int score;

	[SerializeField]GameObject[] Circle;
	int rndCase;
	float posX;
	public float velocity;

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
		Spawn ();
		StartCoroutine (Increment());
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Spawn(){
		//Azul o Rojo
		int rndX = Random.Range (0, 2); 	
		//Pos (-2.12, -0.87, 2.12, -0.87)
		rndCase = Random.Range (0,4);
		switch(rndCase){
			case 3:
				posX = 0.87f;
				break;
			case 2:
				posX = 2.12f;
				break;
			case 1:
				posX = -0.87f;
				break;
			case 0:
				posX = -2.12f;
				break;
			default:
				print ("Error en el Switch!");
				break;
		}
		//Crea el objeto
		Instantiate (Circle[rndX], new Vector3(posX,7,0), Quaternion.identity);
	}

	IEnumerator Increment(){
		for (velocity = -10.0f; velocity > -38f; velocity-=0.25f) {
			yield return new WaitForSeconds (1);
		}
	}

	public void UpdateScore(){
		score++;
		scoreUI.text = "Score: " + score;
	}

	public void GameOver(){
		gameOverText.enabled = true;
	}
		
}