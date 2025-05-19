using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;

public class RoomCreation : MonoBehaviourPunCallbacks
{
    public Button CreateRoomonMapOne;
    public Button CreateRoomonMapTwo;
    public Button CreateRoomonMapThree;
    public Button CreateRoomonMapFour;
    public GameObject RoomCreationMenu;
    public static RoomManager instance;
    public GameObject LoadingScreen;

    void Start()
    {

        if (!PhotonNetwork.IsConnected)
        {
            print("Connecting to server..");
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public void MapOneCreation()
    {
        Photon.Pun.PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        Photon.Pun.PhotonNetwork.JoinLobby("", null, null, null);
        LoadingScreen.SetActive(true);
        RoomCreationMenu.SetActive(false);

    }
    public void MapTwoCreation() 
    {
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 2);
        PhotonNetwork.JoinLobby("", null, null, null);
        LoadingScreen.SetActive(true);
        RoomCreationMenu.SetActive(false);
    }
    public void MapThreeCreation() 
    {
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 3);
        PhotonNetwork.JoinLobby("", null, null, null);
        LoadingScreen.SetActive(true);
        RoomCreationMenu.SetActive(false);
    }


}

