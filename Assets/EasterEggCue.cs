using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;

public class EasterEggCue : MonoBehaviourPunCallbacks
{
    public GameObject EasterEggCueTrigger;
    public AudioSource EasterEggCueAudioSource;

    public bool EasterEggCuePlaying;


    // Start is called before the first frame update
    void Start()
    {
        EasterEggCuePlaying = false;    
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            EasterEggCuePlaying = true;
        }
        
        if (EasterEggCuePlaying == true)
        {
            EasterEggCueAudioSource.Play();
        }
        else
        {
            EasterEggCuePlaying = false;
        }




    }

        
   
}

