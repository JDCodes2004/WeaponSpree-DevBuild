using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
public int health;
public bool isLocalPlayer;

    [Header("UI")]
    public TextMeshProUGUI healthText;
    public Image LowHealthWarning;
    public AudioSource LowHealth;
    public AudioSource CriticalHealth;

    [PunRPC]
    public void TakeDamage (int _damage)
    {
        health -= _damage;

        healthText.text = health.ToString();

        //Low Health Warning

        if (health <= 50)
        {
            LowHealthWarning.enabled = true;
            LowHealth.Play();
            CriticalHealth.Stop();
        }

        if (health <= 25)
        {
            LowHealthWarning.enabled = true;
            CriticalHealth.Play();
            LowHealth.Stop();
        }
        else
        {
            LowHealthWarning.enabled = false;
        }

        //Player Death
        if (health <= 0)
        {
            Destroy(gameObject);
            if (isLocalPlayer)
            {
                RoomManager.instance.SpawnPlayer();

            }


        }
    }
}
