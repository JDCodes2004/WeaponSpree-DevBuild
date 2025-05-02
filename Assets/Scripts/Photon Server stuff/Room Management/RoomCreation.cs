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
    public TextMeshProUGUI OptionsOutput;
    public Button CreateRoom;
    public TMP_Dropdown RoomLevelChoice;


    private int value;

    void HandleInputData(int value)
    {

    }

}

