using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameplayControl : MonoBehaviour {

	public GameObject standbyCam;
	// Use this for initialization
	void Start () {
		standbyCam.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.connectionStateDetailed.ToString () == "Joined") {
			standbyCam.SetActive (false);
		}
	}
}
