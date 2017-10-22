using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField]Text scoreUI;
	public int score;
	[SerializeField]Text lifeUI;
	public int life = 6;
	[SerializeField]Text gameOverText;

	public void UpdateScore(){
		scoreUI.text = "Score: " + score;
	}

	public void UpdateLife(){
		lifeUI.text = "" + life;
	}

	public void GameOver(){
		gameOverText.text = "GAME OVER";
	}
}