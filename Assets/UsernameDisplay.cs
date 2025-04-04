using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class UsernameDisplay : MonoBehaviour
{
    private Transform trans;
    private Vector3 offset = new Vector3(0, 180, 0);
    public string nicknameDisplay;
    // Start is called before the first frame update
    void Start()
    {
        trans = GameObject.Find("Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(PlayerSetup PlayerSetup)
    {
        transform.LookAt(trans);
        transform.Rotate(offset);
       nicknameDisplay = PlayerSetup.nickname;
    }
}
