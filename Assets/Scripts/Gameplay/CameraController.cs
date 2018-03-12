using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Photon.MonoBehaviour {

	public static CameraController Instance;
	private bool doMovement = true;
	public float panSpeed = 30f;
	public float panBorderThickness = 10f;
	public float scrollSpeed = 5f;
	public float minY = 10f;
	public float maxY = 80f;
	private PhotonView PhotonView;
	public bool UseTransformView = true;
	private Vector3 TargetPosition;
	private Quaternion TargetRotation;
	private GameObject turretToBuildx; // prefab of tower need to add more
	public GameObject standardTurretPrefabx;
	public int currentClickNode;

	void Start (){
		Instance = this;
		PhotonView = GetComponent<PhotonView> ();
		CanvasGameplayControl.Instance.loadingImg.SetActive (false);
		photonView.RPC ("RPC_SendSideGameplay",PhotonTargets.All);
		turretToBuildx = standardTurretPrefabx;
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

	private void SmoothMove(){
		if (UseTransformView) {
			return;
		}
		transform.position = Vector3.Lerp (transform.position, TargetPosition, 0.25f);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, TargetRotation, 500 * Time.deltaTime);
	}
	private void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info){
		if (UseTransformView) {
			return;
		}
		if (stream.isWriting) {
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
		} else {
			TargetPosition = (Vector3)stream.ReceiveNext ();
			TargetRotation = (Quaternion)stream.ReceiveNext ();
		}
	}


	[PunRPC]
	private void RPC_SendSideGameplay(){
		//Bug
		CanvasGameplayControl.Instance.sidePlayer[MotherScript.Instance.currentGameSide]++;
	}
		
	public void CreateTower(){
		if (PlayerNetwork.Instance.joinRoomNum == 1) {
			if (currentClickNode == 0) {photonView.RPC ("RPC_CreateTowerP1_0", PhotonTargets.All);} 
			else if (currentClickNode == 1) {photonView.RPC ("RPC_CreateTowerP1_1", PhotonTargets.All);} 
			else if (currentClickNode == 2) {photonView.RPC ("RPC_CreateTowerP1_2", PhotonTargets.All);} 
			else if (currentClickNode == 3) {photonView.RPC ("RPC_CreateTowerP1_3", PhotonTargets.All);} 
			else if (currentClickNode == 4) {photonView.RPC ("RPC_CreateTowerP1_4", PhotonTargets.All);} 
			else if (currentClickNode == 5) {photonView.RPC ("RPC_CreateTowerP1_5", PhotonTargets.All);} 
			else if (currentClickNode == 6) {photonView.RPC ("RPC_CreateTowerP1_6", PhotonTargets.All);} 
			else if (currentClickNode == 7) {photonView.RPC ("RPC_CreateTowerP1_7", PhotonTargets.All);} 
			else if (currentClickNode == 8) {photonView.RPC ("RPC_CreateTowerP1_8", PhotonTargets.All);} 
			else if (currentClickNode == 9) {photonView.RPC ("RPC_CreateTowerP1_9", PhotonTargets.All);} 
			else if (currentClickNode == 10) {photonView.RPC ("RPC_CreateTowerP1_10", PhotonTargets.All);} 
			else if (currentClickNode == 11) {photonView.RPC ("RPC_CreateTowerP1_11", PhotonTargets.All);} 
			else if (currentClickNode == 12) {photonView.RPC ("RPC_CreateTowerP1_12", PhotonTargets.All);} 
			else if (currentClickNode == 13) {photonView.RPC ("RPC_CreateTowerP1_13", PhotonTargets.All);} 
			else if (currentClickNode == 14) {photonView.RPC ("RPC_CreateTowerP1_14", PhotonTargets.All);} 
			else if (currentClickNode == 15) {photonView.RPC ("RPC_CreateTowerP1_15", PhotonTargets.All);} 
			else if (currentClickNode == 16) {photonView.RPC ("RPC_CreateTowerP1_16", PhotonTargets.All);} 
			else if (currentClickNode == 17) {photonView.RPC ("RPC_CreateTowerP1_17", PhotonTargets.All);} 
			else if (currentClickNode == 18) {photonView.RPC ("RPC_CreateTowerP1_18", PhotonTargets.All);} 
			else if (currentClickNode == 19) {photonView.RPC ("RPC_CreateTowerP1_19", PhotonTargets.All);} 
			else if (currentClickNode == 20) {photonView.RPC ("RPC_CreateTowerP1_20", PhotonTargets.All);} 
			else if (currentClickNode == 21) {photonView.RPC ("RPC_CreateTowerP1_21", PhotonTargets.All);} 
			else if (currentClickNode == 22) {photonView.RPC ("RPC_CreateTowerP1_22", PhotonTargets.All);} 
			else if (currentClickNode == 23) {photonView.RPC ("RPC_CreateTowerP1_23", PhotonTargets.All);} 
			else if (currentClickNode == 24) {photonView.RPC ("RPC_CreateTowerP1_24", PhotonTargets.All);} 
			else if (currentClickNode == 25) {photonView.RPC ("RPC_CreateTowerP1_25", PhotonTargets.All);} 
			else if (currentClickNode == 26) {photonView.RPC ("RPC_CreateTowerP1_26", PhotonTargets.All);} 
			else if (currentClickNode == 27) {photonView.RPC ("RPC_CreateTowerP1_27", PhotonTargets.All);} 
			else if (currentClickNode == 28) {photonView.RPC ("RPC_CreateTowerP1_28", PhotonTargets.All);} 
			else if (currentClickNode == 29) {photonView.RPC ("RPC_CreateTowerP1_29", PhotonTargets.All);} 
			else if (currentClickNode == 30) {photonView.RPC ("RPC_CreateTowerP1_30", PhotonTargets.All);} 
			else if (currentClickNode == 31) {photonView.RPC ("RPC_CreateTowerP1_31", PhotonTargets.All);} 
			else if (currentClickNode == 32) {photonView.RPC ("RPC_CreateTowerP1_32", PhotonTargets.All);} 
			else if (currentClickNode == 33) {photonView.RPC ("RPC_CreateTowerP1_33", PhotonTargets.All);} 
			else if (currentClickNode == 34) {photonView.RPC ("RPC_CreateTowerP1_34", PhotonTargets.All);} 
			else if (currentClickNode == 35) {photonView.RPC ("RPC_CreateTowerP1_35", PhotonTargets.All);} 
			else if (currentClickNode == 36) {photonView.RPC ("RPC_CreateTowerP1_36", PhotonTargets.All);} 
			else if (currentClickNode == 37) {photonView.RPC ("RPC_CreateTowerP1_37", PhotonTargets.All);} 
			else if (currentClickNode == 38) {photonView.RPC ("RPC_CreateTowerP1_38", PhotonTargets.All);} 
			else if (currentClickNode == 39) {photonView.RPC ("RPC_CreateTowerP1_39", PhotonTargets.All);} 
			else if (currentClickNode == 40) {photonView.RPC ("RPC_CreateTowerP1_40", PhotonTargets.All);} 
			else if (currentClickNode == 41) {photonView.RPC ("RPC_CreateTowerP1_41", PhotonTargets.All);} 

		}
		else if (PlayerNetwork.Instance.joinRoomNum == 2) {
			if (currentClickNode == 0) {photonView.RPC ("RPC_CreateTowerP2_0", PhotonTargets.All);} 
			else if (currentClickNode == 1) {photonView.RPC ("RPC_CreateTowerP2_1", PhotonTargets.All);}
			else if (currentClickNode == 2) {photonView.RPC ("RPC_CreateTowerP2_2", PhotonTargets.All);}
			else if (currentClickNode == 3) {photonView.RPC ("RPC_CreateTowerP2_3", PhotonTargets.All);}
			else if (currentClickNode == 4) {photonView.RPC ("RPC_CreateTowerP2_4", PhotonTargets.All);}
			else if (currentClickNode == 5) {photonView.RPC ("RPC_CreateTowerP2_5", PhotonTargets.All);}
			else if (currentClickNode == 6) {photonView.RPC ("RPC_CreateTowerP2_6", PhotonTargets.All);}
			else if (currentClickNode == 7) {photonView.RPC ("RPC_CreateTowerP2_7", PhotonTargets.All);}
			else if (currentClickNode == 8) {photonView.RPC ("RPC_CreateTowerP2_8", PhotonTargets.All);}
			else if (currentClickNode == 9) {photonView.RPC ("RPC_CreateTowerP2_9", PhotonTargets.All);}
			else if (currentClickNode == 10) {photonView.RPC ("RPC_CreateTowerP2_10", PhotonTargets.All);}
			else if (currentClickNode == 11) {photonView.RPC ("RPC_CreateTowerP2_11", PhotonTargets.All);}
			else if (currentClickNode == 12) {photonView.RPC ("RPC_CreateTowerP2_12", PhotonTargets.All);}
			else if (currentClickNode == 13) {photonView.RPC ("RPC_CreateTowerP2_13", PhotonTargets.All);}
			else if (currentClickNode == 14) {photonView.RPC ("RPC_CreateTowerP2_14", PhotonTargets.All);}
			else if (currentClickNode == 15) {photonView.RPC ("RPC_CreateTowerP2_15", PhotonTargets.All);}
			else if (currentClickNode == 16) {photonView.RPC ("RPC_CreateTowerP2_16", PhotonTargets.All);}
			else if (currentClickNode == 17) {photonView.RPC ("RPC_CreateTowerP2_17", PhotonTargets.All);}
			else if (currentClickNode == 18) {photonView.RPC ("RPC_CreateTowerP2_18", PhotonTargets.All);}
			else if (currentClickNode == 19) {photonView.RPC ("RPC_CreateTowerP2_19", PhotonTargets.All);}
			else if (currentClickNode == 20) {photonView.RPC ("RPC_CreateTowerP2_20", PhotonTargets.All);}
			else if (currentClickNode == 21) {photonView.RPC ("RPC_CreateTowerP2_21", PhotonTargets.All);}
			else if (currentClickNode == 22) {photonView.RPC ("RPC_CreateTowerP2_22", PhotonTargets.All);}
			else if (currentClickNode == 23) {photonView.RPC ("RPC_CreateTowerP2_23", PhotonTargets.All);}
			else if (currentClickNode == 24) {photonView.RPC ("RPC_CreateTowerP2_24", PhotonTargets.All);}
			else if (currentClickNode == 25) {photonView.RPC ("RPC_CreateTowerP2_25", PhotonTargets.All);}
			else if (currentClickNode == 26) {photonView.RPC ("RPC_CreateTowerP2_26", PhotonTargets.All);}
			else if (currentClickNode == 27) {photonView.RPC ("RPC_CreateTowerP2_27", PhotonTargets.All);}
			else if (currentClickNode == 28) {photonView.RPC ("RPC_CreateTowerP2_28", PhotonTargets.All);}
			else if (currentClickNode == 29) {photonView.RPC ("RPC_CreateTowerP2_29", PhotonTargets.All);}
			else if (currentClickNode == 30) {photonView.RPC ("RPC_CreateTowerP2_30", PhotonTargets.All);}
			else if (currentClickNode == 31) {photonView.RPC ("RPC_CreateTowerP2_31", PhotonTargets.All);}
			else if (currentClickNode == 32) {photonView.RPC ("RPC_CreateTowerP2_32", PhotonTargets.All);}
			else if (currentClickNode == 33) {photonView.RPC ("RPC_CreateTowerP2_33", PhotonTargets.All);}
			else if (currentClickNode == 34) {photonView.RPC ("RPC_CreateTowerP2_34", PhotonTargets.All);}
			else if (currentClickNode == 35) {photonView.RPC ("RPC_CreateTowerP2_35", PhotonTargets.All);}
			else if (currentClickNode == 36) {photonView.RPC ("RPC_CreateTowerP2_36", PhotonTargets.All);}
			else if (currentClickNode == 37) {photonView.RPC ("RPC_CreateTowerP2_37", PhotonTargets.All);}
			else if (currentClickNode == 38) {photonView.RPC ("RPC_CreateTowerP2_38", PhotonTargets.All);}
			else if (currentClickNode == 39) {photonView.RPC ("RPC_CreateTowerP2_39", PhotonTargets.All);}
			else if (currentClickNode == 40) {photonView.RPC ("RPC_CreateTowerP2_40", PhotonTargets.All);}
			else if (currentClickNode == 41) {photonView.RPC ("RPC_CreateTowerP2_41", PhotonTargets.All);}
		}
	}

	[PunRPC]
	private void RPC_CreateTowerP1_0(){Instantiate (turretToBuildx, TestNode1.Instance.node[0].transform.position, TestNode1.Instance.node[0].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_1(){Instantiate (turretToBuildx, TestNode1.Instance.node[1].transform.position, TestNode1.Instance.node[1].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_2(){Instantiate (turretToBuildx, TestNode1.Instance.node[2].transform.position, TestNode1.Instance.node[2].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_3(){Instantiate (turretToBuildx, TestNode1.Instance.node[3].transform.position, TestNode1.Instance.node[3].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_4(){Instantiate (turretToBuildx, TestNode1.Instance.node[4].transform.position, TestNode1.Instance.node[4].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_5(){Instantiate (turretToBuildx, TestNode1.Instance.node[5].transform.position, TestNode1.Instance.node[5].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_6(){Instantiate (turretToBuildx, TestNode1.Instance.node[6].transform.position, TestNode1.Instance.node[6].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_7(){Instantiate (turretToBuildx, TestNode1.Instance.node[7].transform.position, TestNode1.Instance.node[7].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_8(){Instantiate (turretToBuildx, TestNode1.Instance.node[8].transform.position, TestNode1.Instance.node[8].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_9(){Instantiate (turretToBuildx, TestNode1.Instance.node[9].transform.position, TestNode1.Instance.node[9].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_10(){Instantiate (turretToBuildx, TestNode1.Instance.node[10].transform.position, TestNode1.Instance.node[10].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_11(){Instantiate (turretToBuildx, TestNode1.Instance.node[11].transform.position, TestNode1.Instance.node[11].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_12(){Instantiate (turretToBuildx, TestNode1.Instance.node[12].transform.position, TestNode1.Instance.node[12].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_13(){Instantiate (turretToBuildx, TestNode1.Instance.node[13].transform.position, TestNode1.Instance.node[13].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_14(){Instantiate (turretToBuildx, TestNode1.Instance.node[14].transform.position, TestNode1.Instance.node[14].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_15(){Instantiate (turretToBuildx, TestNode1.Instance.node[15].transform.position, TestNode1.Instance.node[15].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_16(){Instantiate (turretToBuildx, TestNode1.Instance.node[16].transform.position, TestNode1.Instance.node[16].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_17(){Instantiate (turretToBuildx, TestNode1.Instance.node[17].transform.position, TestNode1.Instance.node[17].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_18(){Instantiate (turretToBuildx, TestNode1.Instance.node[18].transform.position, TestNode1.Instance.node[18].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_19(){Instantiate (turretToBuildx, TestNode1.Instance.node[19].transform.position, TestNode1.Instance.node[19].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_20(){Instantiate (turretToBuildx, TestNode1.Instance.node[20].transform.position, TestNode1.Instance.node[20].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_21(){Instantiate (turretToBuildx, TestNode1.Instance.node[21].transform.position, TestNode1.Instance.node[21].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_22(){Instantiate (turretToBuildx, TestNode1.Instance.node[22].transform.position, TestNode1.Instance.node[22].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_23(){Instantiate (turretToBuildx, TestNode1.Instance.node[23].transform.position, TestNode1.Instance.node[23].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_24(){Instantiate (turretToBuildx, TestNode1.Instance.node[24].transform.position, TestNode1.Instance.node[24].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_25(){Instantiate (turretToBuildx, TestNode1.Instance.node[25].transform.position, TestNode1.Instance.node[25].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_26(){Instantiate (turretToBuildx, TestNode1.Instance.node[26].transform.position, TestNode1.Instance.node[26].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_27(){Instantiate (turretToBuildx, TestNode1.Instance.node[27].transform.position, TestNode1.Instance.node[27].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_28(){Instantiate (turretToBuildx, TestNode1.Instance.node[28].transform.position, TestNode1.Instance.node[28].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_29(){Instantiate (turretToBuildx, TestNode1.Instance.node[29].transform.position, TestNode1.Instance.node[29].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_30(){Instantiate (turretToBuildx, TestNode1.Instance.node[30].transform.position, TestNode1.Instance.node[30].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_31(){Instantiate (turretToBuildx, TestNode1.Instance.node[31].transform.position, TestNode1.Instance.node[31].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_32(){Instantiate (turretToBuildx, TestNode1.Instance.node[32].transform.position, TestNode1.Instance.node[32].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_33(){Instantiate (turretToBuildx, TestNode1.Instance.node[33].transform.position, TestNode1.Instance.node[33].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_34(){Instantiate (turretToBuildx, TestNode1.Instance.node[34].transform.position, TestNode1.Instance.node[34].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_35(){Instantiate (turretToBuildx, TestNode1.Instance.node[35].transform.position, TestNode1.Instance.node[35].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_36(){Instantiate (turretToBuildx, TestNode1.Instance.node[36].transform.position, TestNode1.Instance.node[36].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_37(){Instantiate (turretToBuildx, TestNode1.Instance.node[37].transform.position, TestNode1.Instance.node[37].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_38(){Instantiate (turretToBuildx, TestNode1.Instance.node[38].transform.position, TestNode1.Instance.node[38].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_39(){Instantiate (turretToBuildx, TestNode1.Instance.node[39].transform.position, TestNode1.Instance.node[39].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_40(){Instantiate (turretToBuildx, TestNode1.Instance.node[40].transform.position, TestNode1.Instance.node[40].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP1_41(){Instantiate (turretToBuildx, TestNode1.Instance.node[41].transform.position, TestNode1.Instance.node[41].transform.rotation);}

	[PunRPC]
	private void RPC_CreateTowerP2_0(){Instantiate (turretToBuildx, TestNode2.Instance.node[0].transform.position, TestNode2.Instance.node[0].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_1(){Instantiate (turretToBuildx, TestNode2.Instance.node[1].transform.position, TestNode2.Instance.node[1].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_2(){Instantiate (turretToBuildx, TestNode2.Instance.node[2].transform.position, TestNode2.Instance.node[2].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_3(){Instantiate (turretToBuildx, TestNode2.Instance.node[3].transform.position, TestNode2.Instance.node[3].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_4(){Instantiate (turretToBuildx, TestNode2.Instance.node[4].transform.position, TestNode2.Instance.node[4].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_5(){Instantiate (turretToBuildx, TestNode2.Instance.node[5].transform.position, TestNode2.Instance.node[5].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_6(){Instantiate (turretToBuildx, TestNode2.Instance.node[6].transform.position, TestNode2.Instance.node[6].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_7(){Instantiate (turretToBuildx, TestNode2.Instance.node[7].transform.position, TestNode2.Instance.node[7].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_8(){Instantiate (turretToBuildx, TestNode2.Instance.node[8].transform.position, TestNode2.Instance.node[8].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_9(){Instantiate (turretToBuildx, TestNode2.Instance.node[9].transform.position, TestNode2.Instance.node[9].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_10(){Instantiate (turretToBuildx, TestNode2.Instance.node[10].transform.position, TestNode2.Instance.node[10].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_11(){Instantiate (turretToBuildx, TestNode2.Instance.node[11].transform.position, TestNode2.Instance.node[11].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_12(){Instantiate (turretToBuildx, TestNode2.Instance.node[12].transform.position, TestNode2.Instance.node[12].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_13(){Instantiate (turretToBuildx, TestNode2.Instance.node[13].transform.position, TestNode2.Instance.node[13].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_14(){Instantiate (turretToBuildx, TestNode2.Instance.node[14].transform.position, TestNode2.Instance.node[14].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_15(){Instantiate (turretToBuildx, TestNode2.Instance.node[15].transform.position, TestNode2.Instance.node[15].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_16(){Instantiate (turretToBuildx, TestNode2.Instance.node[16].transform.position, TestNode2.Instance.node[16].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_17(){Instantiate (turretToBuildx, TestNode2.Instance.node[17].transform.position, TestNode2.Instance.node[17].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_18(){Instantiate (turretToBuildx, TestNode2.Instance.node[18].transform.position, TestNode2.Instance.node[18].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_19(){Instantiate (turretToBuildx, TestNode2.Instance.node[19].transform.position, TestNode2.Instance.node[19].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_20(){Instantiate (turretToBuildx, TestNode2.Instance.node[20].transform.position, TestNode2.Instance.node[20].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_21(){Instantiate (turretToBuildx, TestNode2.Instance.node[21].transform.position, TestNode2.Instance.node[21].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_22(){Instantiate (turretToBuildx, TestNode2.Instance.node[22].transform.position, TestNode2.Instance.node[22].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_23(){Instantiate (turretToBuildx, TestNode2.Instance.node[23].transform.position, TestNode2.Instance.node[23].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_24(){Instantiate (turretToBuildx, TestNode2.Instance.node[24].transform.position, TestNode2.Instance.node[24].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_25(){Instantiate (turretToBuildx, TestNode2.Instance.node[25].transform.position, TestNode2.Instance.node[25].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_26(){Instantiate (turretToBuildx, TestNode2.Instance.node[26].transform.position, TestNode2.Instance.node[26].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_27(){Instantiate (turretToBuildx, TestNode2.Instance.node[27].transform.position, TestNode2.Instance.node[27].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_28(){Instantiate (turretToBuildx, TestNode2.Instance.node[28].transform.position, TestNode2.Instance.node[28].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_29(){Instantiate (turretToBuildx, TestNode2.Instance.node[29].transform.position, TestNode2.Instance.node[29].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_30(){Instantiate (turretToBuildx, TestNode2.Instance.node[30].transform.position, TestNode2.Instance.node[30].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_31(){Instantiate (turretToBuildx, TestNode2.Instance.node[31].transform.position, TestNode2.Instance.node[31].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_32(){Instantiate (turretToBuildx, TestNode2.Instance.node[32].transform.position, TestNode2.Instance.node[32].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_33(){Instantiate (turretToBuildx, TestNode2.Instance.node[33].transform.position, TestNode2.Instance.node[33].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_34(){Instantiate (turretToBuildx, TestNode2.Instance.node[34].transform.position, TestNode2.Instance.node[34].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_35(){Instantiate (turretToBuildx, TestNode2.Instance.node[35].transform.position, TestNode2.Instance.node[35].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_36(){Instantiate (turretToBuildx, TestNode2.Instance.node[36].transform.position, TestNode2.Instance.node[36].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_37(){Instantiate (turretToBuildx, TestNode2.Instance.node[37].transform.position, TestNode2.Instance.node[37].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_38(){Instantiate (turretToBuildx, TestNode2.Instance.node[38].transform.position, TestNode2.Instance.node[38].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_39(){Instantiate (turretToBuildx, TestNode2.Instance.node[39].transform.position, TestNode2.Instance.node[39].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_40(){Instantiate (turretToBuildx, TestNode2.Instance.node[40].transform.position, TestNode2.Instance.node[40].transform.rotation);}
	[PunRPC]
	private void RPC_CreateTowerP2_41(){Instantiate (turretToBuildx, TestNode2.Instance.node[41].transform.position, TestNode2.Instance.node[41].transform.rotation);}
		
}
