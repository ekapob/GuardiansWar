﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNode1 : MonoBehaviour {

	public static TestNode1 Instance;
	public GameObject[] node;
	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}