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
    public GameObject MapErrorPanel;
    public static RoomManager instance;

    public void MapOneCreation(PhotonNetwork photonNetwork)
    {
        PhotonNetwork.JoinOrCreateRoom;
        Photon.Pun.PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        Photon.Pun.PhotonNetwork.CreateRoom("", null, null, null);

    }
    public void MapTwoCreation() 
    {
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 2);
        PhotonNetwork.CreateRoom("", null, null, null);
    }
    public void MapThreeCreation() 
    {
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 3);
        PhotonNetwork.CreateRoom("", null, null, null);
    }


}

