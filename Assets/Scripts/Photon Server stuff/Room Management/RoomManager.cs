using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;

    public GameObject playerPrefab;
    [Space]
    public Transform[] spawnPoints;
    [Space]
    public GameObject roomCamera;


    public GameObject nameUI;

    [SerializeField] private TMP_InputField nameinput;
    [SerializeField] private int maxCharacters = 26;

    public GameObject connectingUI;

    public string nickname = "unnamed player";


    public string roomNameToJoin = "Test-Server";

    public void Awake()
    {
        instance = this;
    }
    public void ChangeNickname(string _name)
    {
        nickname = _name;
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
        if (nameinput != null)
        {
            nameinput.characterLimit = maxCharacters;
        }

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
        Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

        GameObject _playerPrefab = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity);
        _playerPrefab.GetComponent<PlayerSetup>().IsLocalPlayer();
        _playerPrefab.GetComponent<Health>().isLocalPlayer = true;

        _playerPrefab.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.All, nickname);
        PhotonNetwork.LocalPlayer.NickName = nickname;
    }
}
