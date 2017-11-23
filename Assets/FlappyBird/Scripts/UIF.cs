using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIF : MonoBehaviour {

	[SerializeField]Text scoreUI;
	int score;
	[SerializeField]Image gameOverText;
	[SerializeField]Image play;

	public void UpdateScore(){
		score++;
		scoreUI.text = "Score: " + score;
	}
		
	public void GameOver(){
		gameOverText.enabled = true;
	}
	public void Play(){
		play.enabled = false;
	}
}