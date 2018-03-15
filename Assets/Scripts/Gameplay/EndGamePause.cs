using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePause : MonoBehaviour {

	void Start () 
	{
		Time.timeScale = 0f;
	}
}
