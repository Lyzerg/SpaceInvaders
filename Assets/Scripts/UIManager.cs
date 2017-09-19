﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField]Text scoreUI;
	public int score;

	public void UpdateScore(){
		scoreUI.text = "Score: " + score;
	}
}