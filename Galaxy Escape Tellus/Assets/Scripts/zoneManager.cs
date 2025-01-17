using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneManager : MonoBehaviour
{
    public GameObject colliders;
    public GameObject footsteps;
    public zone zone;
    public zone2 zone2;
    public zone3 zone3;

    public Light spotLightYellow;
    public Light spotLightGreen;
    public Light spotLightBlue;

    public AudioSource audioSource;
    private bool audioPlayed = false;

    
    void Start() 
    {
        spotLightYellow.enabled = false;
        spotLightGreen.enabled = false;
        spotLightBlue.enabled = false;
    }

//tarkistaa että kaikki on laatoilla
    // Update is called once per frame
    void Update()
    {
        if(zone.player1 && zone2.player2 && zone3.player3){
            //nyt kaikki pelaajat on laatoilla
            colliders.SetActive(false);
            footsteps.SetActive(true);
            //Debug.Log("New area unlocked!");
            
            //all lights turned on 
            spotLightYellow.enabled = true;
            spotLightGreen.enabled = true;
            spotLightBlue.enabled = true;

            if(audioPlayed == false) {
                audioSource.Play();
                audioPlayed = true;
            }
            

        }
        
    }

}
