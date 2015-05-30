using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters;

public class NetworkPlayer : Photon.MonoBehaviour {

	public GameObject playerCamera;
	public GameObject playerCharacter;

	private bool isAlive = true;
	private Vector3 position;
	private Quaternion rotation;
	private float lerpSmoothing = 5;

	// Use this for initialization
	void Start () {
		if (photonView.isMine) {
			// Local player
			playerCamera.SetActive (true);
			playerCharacter.GetComponent<ThirdPersonMouseControl>().enabled = true;
		} else {
			// Remote Network player
			StartCoroutine("Alive");
		}
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			stream.SendNext(playerCharacter.transform.position);
			stream.SendNext(playerCharacter.transform.rotation);
		} else {
			position = (Vector3) stream.ReceiveNext();
			rotation = (Quaternion) stream.ReceiveNext();
		}
	}

	//while alive do this
	IEnumerator Alive(){
		while (isAlive) {
			// Update the position and rotation
			playerCharacter.transform.position = Vector3.Lerp (playerCharacter.transform.position, position, Time.deltaTime*lerpSmoothing);
			playerCharacter.transform.rotation = Quaternion.Lerp (playerCharacter.transform.rotation, rotation, Time.deltaTime*lerpSmoothing);
			//TODO FIX THIS
			//TODO FIX THIS
			//TODO FIX THIS
			//TODO >>>>>>>>>>>
			// Update the animator
			/*
			Vector3 movementVector = position-playerCharacter.transform.position;
			movementVector.Normalize();
			playerCharacter.transform.FindChild("AIThirdPersonController").GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().RemoteUpdateAnimator(movementVector);
			*/
			//TODO <<<<<<<<<<<
			//TODO FIX THIS
			//TODO FIX THIS
			//TODO FIX THIS


			yield return null;
		}
	}
}
