using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Photon.MonoBehaviour {

	private bool doMovement = true;
	public float panSpeed = 30f;
	public float panBorderThickness = 10f;
	public float scrollSpeed = 5f;
	public float minY = 10f;
	public float maxY = 80f;
	private PhotonView PhotonView;

	void Start (){
		PhotonView = GetComponent<PhotonView> ();
		CanvasGameplayControl.Instance.loadingImg.SetActive (false);
		photonView.RPC ("RPC_SendSideGameplay",PhotonTargets.All);
	}
	void Update ()
	{
		if (!PauseAndExitButton.Instance.pause && photonView.isMine) {
			MoveCode ();
		}
	}

	private void MoveCode(){
		if (Input.GetKeyDown (KeyCode.Escape))
			doMovement = !doMovement;

		if (!doMovement)
			return;

		if (Input.GetKey ("w") || Input.GetKey (KeyCode.UpArrow)/*|| Input.mousePosition.y >= Screen.height - panBorderThickness*/) {
			transform.Translate (Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey ("s") || Input.GetKey (KeyCode.DownArrow)/*|| Input.mousePosition.y <= panBorderThickness*/) {
			transform.Translate (Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey ("d") || Input.GetKey (KeyCode.RightArrow)/*|| Input.mousePosition.x >= Screen.width - panBorderThickness*/) {
			transform.Translate (Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey ("a") || Input.GetKey (KeyCode.LeftArrow)/*|| Input.mousePosition.x <= panBorderThickness*/) {
			transform.Translate (Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y += scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		transform.position = pos;
	}




	[PunRPC]
	private void RPC_SendSideGameplay(){
		//Bug
		CanvasGameplayControl.Instance.sidePlayer[MotherScript.Instance.currentGameSide]++;
	}

	/*[PunRPC]
	private void RPC_BuildTurret(TurretBlueprint blueprint)
	{
		if(PlayerStats.Money<blueprint.cost)
		{
			Debug.Log ("Not enough gold!");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate (blueprint.prefabs,  GetBuildPosition (), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		Debug.Log (PlayerStats.Money);
	}*/
}
