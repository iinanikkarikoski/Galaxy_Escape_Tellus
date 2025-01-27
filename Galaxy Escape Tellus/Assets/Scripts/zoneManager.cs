using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneManager : MonoBehaviour
{
    public GameObject colliders;
    public GameObject footsteps_from_2to3;
    public GameObject footsteps_from_1to2;
    public zone zone;
    public zone2 zone2;
    public zone3 zone3;

    public Light spotLightYellow;
    public Light spotLightGreen;
    public Light spotLightBlue;

    public AudioSource audioSource;
    private bool audioPlayed = false;


    // Light flashing script
    public LightChanges lightChanges;

    
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
            footsteps_from_2to3.SetActive(true);
            footsteps_from_1to2.SetActive(false);
            //Debug.Log("New area unlocked!");
            
            //all lights turned on 
            spotLightYellow.enabled = true;
            spotLightGreen.enabled = true;
            spotLightBlue.enabled = true;

            if (lightChanges != null)
            {
                lightChanges.FinishedLight();
            }

            if(audioPlayed == false) {
                audioSource.Play();
                audioPlayed = true;
            }
            
        }
        
    }

}
