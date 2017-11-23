using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorUI : MonoBehaviour {

	[SerializeField]Text scoreTxt;
	[SerializeField]Text win;
	int score;

	// Use this for initialization
	void Start () {
//		StartCoroutine (Win());
	}
	
	// Update is called once per frame
	void Update () {
		if (score == 10){
			Win();
		}
	}

	public void UpdateScore(){
		score++;
		scoreTxt.text = "Score: " + score;
	}

	void Win(){
		GameManager3DC.GM.win = true;
		win.text = "You Win!";
	}
	public void Loose(){
		GameManager3DC.GM.gameOver = true;
		win.text = "You Lose!";
	}
}
