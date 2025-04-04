using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{
    public GameObject Player;
    public GameObject Playercamera;

    public string nickname;
    public void IsLocalPlayer()
    {
        Player.SetActive(true);
        Playercamera.SetActive(true);
    }


    [PunRPC]
    public void SetNickname(string _name)
    {
        nickname = _name;
    }
}
