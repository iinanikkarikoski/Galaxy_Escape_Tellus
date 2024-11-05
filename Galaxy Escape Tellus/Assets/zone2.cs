using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone2 : MonoBehaviour
{
    public bool player2 = false;
    public Light spotLightGreen;
    
    public void Start() {
        if (spotLightGreen != null) {
            spotLightGreen.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collision){
        
        if (collision.gameObject.tag == "player 2"){
            //pelaaja 2 on laatalla
            player2 = true;

            if (spotLightGreen != null)
            {
                // Turn on the point light
                spotLightGreen.enabled = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider collision){
        
        if (collision.gameObject.tag == "player 2"){
            //pelaaja 2 poistui laatalta
            player2 = false;

            if (spotLightGreen != null)
            {
                // Turn off the point light
                spotLightGreen.enabled = false;
            }
        }
        
    }
}
