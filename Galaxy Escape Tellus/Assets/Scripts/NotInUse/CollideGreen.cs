using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollideGreen : MonoBehaviour
{
    public GameObject capsule;
    public Light spotLight;

    public void Start() {
        if (spotLight != null) {
            spotLight.enabled = false;
        }
    }

    void OnTriggerEnter(Collider collision) {

        if(collision.gameObject.tag == "player 2") {

            capsule.SetActive(true);

            if (spotLight != null)
            {
                // Turn on the point light
                spotLight.enabled = true;
            }
        
        }
    }
    void OnTriggerExit(Collider collision) {

        if(collision.gameObject.tag == "player 2") {

            capsule.SetActive(false);
        
            if (spotLight != null)
            {
                // Turn off the point light
                spotLight.enabled = false;
            }
        }
    }
}
