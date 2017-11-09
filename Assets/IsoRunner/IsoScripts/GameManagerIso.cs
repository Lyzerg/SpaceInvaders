using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerIso : MonoBehaviour {

	public static GameManagerIso GM;

	[SerializeField]GameObject[] boulder;
	[SerializeField]Text scoreUI;
	[SerializeField]Text gameOverUI;
	[SerializeField]Image redUI;
	public float velocity;
	float time;
	public bool gameOver;

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
		velocity = -10.0f;
		Spawner ();
		StartCoroutine (Increment());

	}

	void Update(){
		if(!gameOver){
			time += Time.deltaTime;
			scoreUI.text = "Time: " + time; //NO esta bien conectado el timepo
		}
	}

	public void Spawner(){
		if(!gameOver){
			int rndObj = Random.Range (0, 2);
			int rndPos = Random.Range (-4,5);
			Instantiate (boulder[rndObj], new Vector3(rndPos,-0.5f,24), Quaternion.identity);
		}
	}

	IEnumerator Increment(){
		for (velocity = -15; velocity > -70; velocity--) {
			yield return new WaitForSeconds (1);
		}
	}

	public void GameOver(){
		redUI.enabled = true;
		gameOverUI.enabled = true;
		scoreUI.color = Color.black;
		gameOver = true;
		//crea es sist de part
	}
}
