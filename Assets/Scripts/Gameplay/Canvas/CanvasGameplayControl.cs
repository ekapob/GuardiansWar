﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameplayControl : MonoBehaviour {

	public static CanvasGameplayControl Instance;
	public GameObject standbyCam;
	private int allPlayerInGame;
	public GameObject loadingImg;
	public int knightPlayer;
	public int monsterPlayer;

	// Use this for initialization
	void Start () {
		knightPlayer = 0;
		monsterPlayer = 0;
		Instance = this;
		allPlayerInGame = PhotonNetwork.playerList.Length;
		standbyCam.SetActive (true);
		if (allPlayerInGame == 2){
			NodeControlForPlayer.Instance.playerNodeK2.SetActive (true);
			NodeControlForPlayer.Instance.playerNodeM1.SetActive (true);
		} else if (allPlayerInGame == 3) {
		} else if (allPlayerInGame == 4) {
			NodeControlForPlayer.Instance.playerNodeK2.SetActive (true);
			NodeControlForPlayer.Instance.playerNodeM1.SetActive (true);
			NodeControlForPlayer.Instance.playerNodeK1.SetActive (true);
			NodeControlForPlayer.Instance.playerNodeM2.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.connectionStateDetailed.ToString () == "Joined") {
			standbyCam.SetActive (false);
		}

		if (allPlayerInGame != PhotonNetwork.playerList.Length) {
			PauseAndExitButton.Instance.pause = true;
			PauseAndExitButton.Instance.allButton.SetActive (true);
			PauseAndExitButton.Instance.exitButton.SetActive (false);
		}
	}
}
