using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone3 : MonoBehaviour
{
    public bool player3 = false;
    public Light spotLightBlue;

    public void Start() {
        if (spotLightBlue != null) {
            spotLightBlue.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collision){
        
        if (collision.gameObject.tag == "player 3"){
            player3 = true;

            if (spotLightBlue != null)
            {
                // Turn on the point light
                spotLightBlue.enabled = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider collision){
        
        if (collision.gameObject.tag == "player 3"){
            player3 = false;

            if (spotLightBlue != null)
            {
                // Turn on the point light
                spotLightBlue.enabled = false;
            }
        }
        
    }
}
