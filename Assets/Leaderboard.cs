using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using TMPro;

public class Leaderboard : MonoBehaviour
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
    }
}
