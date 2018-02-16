using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCanvas : MonoBehaviour {

	public static TestCanvas Instance;
	public GameObject standCam;
	private int allPlayerInGame;
	public GameObject Img;
	public int[] sidePlayer = new int[2] {0,0};
	// Use this for initialization
	void Start () {
		Instance = this;
		allPlayerInGame = PhotonNetwork.playerList.Length;
		standCam.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
