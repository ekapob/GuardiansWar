using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameplayControl : MonoBehaviour {

	public GameObject standbyCam;
	private int allPlayerInGame;
	// Use this for initialization
	void Start () {
		allPlayerInGame = PhotonNetwork.playerList.Length;
		standbyCam.SetActive (true);
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
