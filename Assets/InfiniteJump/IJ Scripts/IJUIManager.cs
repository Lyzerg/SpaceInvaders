using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IJUIManager : MonoBehaviour {

	[SerializeField]Text scoreUI;
	[SerializeField]Text gameOverUI;
	[SerializeField]Image redUI;
	int score = -1;

	public void UpdateCounter(){
		score += 1;
		scoreUI.text = "Score: " + score;
	}

	public void GameOver(){
		redUI.enabled = true;
		gameOverUI.enabled = true;
		scoreUI.color = Color.black;
	}
}
