using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;

    public GameObject playerPrefab;
    [Space]
    public Transform spawnPoint;
    [Space]
    public GameObject roomCamera;


    public GameObject nameUI;

    public GameObject connectingUI;

    private string nickname = "unnamed player";


    public string roomNameToJoin = "test";

    private void Awake()
    {
        instance = this;
    }


    public void JoinRoomButtonPressed()
    {
        Debug.Log("Connecting.. Please wait :)");

        PhotonNetwork.ConnectUsingSettings();

        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message: "Connecting...");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log(message: "Connected to Server. Welcome!");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom(roomNameToJoin, roomOptions: null, typedLobby: null);

        Debug.Log(message: "We're connected and in a room now");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Room");
        roomCamera.SetActive(false);
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GameObject _playerPrefab = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity);
        _playerPrefab.GetComponent<PlayerSetup>().IsLocalPlayer();
        _playerPrefab.GetComponent<Health>().isLocalPlayer = true;
    }
}
