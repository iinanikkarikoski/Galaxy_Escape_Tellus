using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone : MonoBehaviour
{
    public bool player1 = false;
    public Light spotLightYellow;

    public void Start() {
        if (spotLightYellow != null) {
            spotLightYellow.enabled = false;
        }
    }
    

    private void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag == "player 1"){
            player1 = true;

            if (spotLightYellow != null)
            {
                // Turn on the point light
                spotLightYellow.enabled = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider collision){
        if (collision.gameObject.tag == "player 1"){
            player1 = false;

            if (spotLightYellow != null)
            {
                // Turn off the point light
                spotLightYellow.enabled = false;
            }
        }
        
    }
}
