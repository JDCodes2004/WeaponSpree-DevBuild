using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using TMPro;

public class Leaderboard : MonoBehaviourPunCallbacks
{
    public GameObject playersHolder;

    [Header("Options")] 
    public float refreshRate = 1f;

    [Header("UI")] 
    public GameObject[] slots;
    [Space] 
    public TextMeshProUGUI[] scoreTexts;
    public TextMeshProUGUI[] nameTexts;



    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(Refresh), 1f, refreshRate);
    }

    public void Refresh()
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);
        }

        var sortedPlayerList =
       (from player in PhotonNetwork.PlayerList orderby player.GetScore() descending select player).ToList();

        int i = 0;
        foreach (var player in sortedPlayerList) 
        {
         slots[i].SetActive(true);

            if (player.NickName == "")
                player.NickName = "unnamed";

            nameTexts[i].text = player.NickName;
            scoreTexts[i].text = player.GetScore().ToString();

            i++;

        }
    }

    private void Update()
    {
      playersHolder.SetActive(Input.GetKey(KeyCode.Tab));
    }
}
