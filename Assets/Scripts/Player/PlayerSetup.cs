using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviour
{
    public GameObject Player;
    public GameObject Playercamera;
    public GameObject PauseMenuCanvas;

    public string nickname;

    public TextMeshPro NicknameThirdPersonDisplay;

    public bool GamePaused = false;
    public void IsLocalPlayer()
    {
        Player.SetActive(true);
        Playercamera.SetActive(true);
    }


    [PunRPC]
    public void SetNickname(string _name)
    {
        nickname = _name;
        NicknameThirdPersonDisplay.text = nickname;
    }

    [PunRPC]
    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused = true;
        }
        else
        {
            GamePaused &= false;
        }

        if (GamePaused == true)
        {
            PauseMenuCanvas.SetActive(true);

        }
        else
        {
            PauseMenuCanvas.SetActive(false);
            GamePaused = false;
        }
    }
}
