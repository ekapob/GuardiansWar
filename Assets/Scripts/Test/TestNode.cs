﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNode : MonoBehaviour {

	public int nodeNo;
	public Color hoverColor;
	private GameObject turret;
	private Renderer rend;
	private Color startColor;
	public static TestNode Instance;

	// Use this for initialization
	void Start () {
		Instance = this;
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}


	public void OnMouseEnter(){
		if(PlayerNetwork.Instance.joinRoomNum.ToString() == tag)
			rend.material.color = hoverColor;
	}

	public void OnMouseDown(){
		if (PlayerNetwork.Instance.joinRoomNum.ToString () == tag) {
			if (turret != null) {
				Debug.Log ("Not Null Dude");
				return;
			}
			CameraController.Instance.currentClickNode = nodeNo;
			Debug.Log ("Current : "+CameraController.Instance.currentClickNode);
			CameraController.Instance.CreateTower ();
			turret = this.gameObject;
		}
	}

	public void OnMouseExit(){
		rend.material.color = startColor;
	}

}