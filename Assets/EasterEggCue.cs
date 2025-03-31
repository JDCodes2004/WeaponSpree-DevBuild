using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;

public class EasterEggCue : MonoBehaviourPunCallbacks
{
    public GameObject EasterEggCueTrigger;
    public GameObject EasterEggCueAudioSource;

    public bool EasterEggCuePlaying;


    // Start is called before the first frame update
    void Start()
    {
        EasterEggCuePlaying = false;    
    }

    private void OnTriggerEnter(Collider other)
    {
        EasterEggCuePlaying = true;
    }

    private void OnTriggerExit(Collider other)
    {
        EasterEggCuePlaying = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (EasterEggCuePlaying == true)
        {
            EasterEggCueAudioSource.SetActive(true);
        }
        else
        {
            EasterEggCuePlaying = false;
            EasterEggCueAudioSource.SetActive(false);
        }
    }
    // Dev note to self: Am I seriously taking
    // too much inspiration from Halo?
    // I mean, I added the "Siege of Madrigal"
    // easter egg from the games.
    
}

