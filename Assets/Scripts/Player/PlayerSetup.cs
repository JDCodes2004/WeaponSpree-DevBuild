using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public GameObject Player;
    public GameObject Playercamera;


    public void IsLocalPlayer()
    {
        Player.SetActive(true);
        Playercamera.SetActive(true);
    }

}
