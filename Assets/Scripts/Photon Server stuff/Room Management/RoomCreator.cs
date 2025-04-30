using System.Collections;
using System.Collections.Generic;

using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomCreator : MonoBehaviour
{

    public TMPro.TMP_Dropdown MapSelection;
    public Scene[] MapOfChoice;
    public Button CreateRoom;



    public void Create()
    {
        RoomOptions options = new RoomOptions();

        ExitGames.Client.Photon.Hashtable properties = new ExitGames.Client.Photon.Hashtable();
        properties.Add("map", RoomList.MapData.currentmap);
        properties.Add("mode", (int)GameSettings.GameMode);
        options.CustomRoomProperties = properties;

        PhotonNetwork.CreateRoom(roomnameField.text, options);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
