using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneManagerBossBattle : MonoBehaviour
{
    public zone zone;
    public zone2 zone2;
    public zone3 zone3;

    public Light spotLightYellow;
    public Light spotLightGreen;
    public Light spotLightBlue;

    public AudioSource audioSource;
    private bool audioPlayed = false;

    public GameObject gun_yellow;
    public GameObject gun_green;
    public GameObject gun_blue;

    public GameObject progressbar;

    //goes to the walk anims script to activate the walk with gun
    public bool visited;



    // Light flashing script
    public LightChanges lightChanges;

    
    void Start() 
    {
        spotLightYellow.enabled = false;
        spotLightGreen.enabled = false;
        spotLightBlue.enabled = false;

        visited = false;

        //change to false! for testing these are true
        gun_yellow.SetActive(false);
        gun_green.SetActive(false);
        gun_blue.SetActive(false);
        progressbar.SetActive(false);
    }

//tarkistaa että kaikki on laatoilla
    // Update is called once per frame
    void Update()
    {
        if(zone.player1 && zone2.player2 && zone3.player3){
            //nyt kaikki pelaajat on laatoilla
  
            //all lights turned on 
            spotLightYellow.enabled = true;
            spotLightGreen.enabled = true;
            spotLightBlue.enabled = true;

            visited = true;

            if (lightChanges != null)
            {
                lightChanges.FinishedLight();
            }

            if(audioPlayed == false) {
                audioSource.Play();
                audioPlayed = true;
            }

            gun_yellow.SetActive(true);
            gun_green.SetActive(true);
            gun_blue.SetActive(true);
            progressbar.SetActive(true);            
        }
        
    }

}
