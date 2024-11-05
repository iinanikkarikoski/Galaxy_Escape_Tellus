using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneManager : MonoBehaviour
{
    public GameObject obj;
    public zone zone;
    public zone2 zone2;
    public zone3 zone3;

    public Light spotLightYellow;
    public Light spotLightGreen;
    public Light spotLightBlue;

    
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
            obj.SetActive(true);
            
            //all lights turned on 
            spotLightYellow.enabled = true;
            spotLightGreen.enabled = true;
            spotLightBlue.enabled = true;

        }
        
    }

}
