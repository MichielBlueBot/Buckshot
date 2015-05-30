using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string GAME_VERSION = "v0.0.1";
	public string ROOM_NAME = "BuckshotRoomDefault";

	private int nextSpawnedPlayerTeam = 1;

	public Transform spawn1;
	public Transform spawn2; 

	// All these prefabs need to be in the Prefabs/Resources/ root folder.
	public string playerPrefabName = "Player";

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings (GAME_VERSION);
	}

	void OnJoinedLobby(){
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom(ROOM_NAME, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom(){
		if (nextSpawnedPlayerTeam == 1) {
			PhotonNetwork.Instantiate (playerPrefabName, spawn1.position, spawn1.rotation, 0);
			nextSpawnedPlayerTeam = 2;
		} else {
			PhotonNetwork.Instantiate (playerPrefabName, spawn2.position, spawn1.rotation, 0);
			nextSpawnedPlayerTeam = 1;
		}
	}
}
