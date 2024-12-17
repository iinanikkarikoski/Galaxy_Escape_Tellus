using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Collide : MonoBehaviour
{
    public GameObject capsule;

    void OnCollisionEnter(Collision collision) {

        if(collision.gameObject.tag == "player 1" || collision.gameObject.tag == "player 2" || collision.gameObject.tag == "player 3") {

            capsule.SetActive(true);
        
        }
    }
    void OnCollisionExit(Collision collision) {

        if(collision.gameObject.tag == "player 1" || collision.gameObject.tag == "player 2" || collision.gameObject.tag == "player 3") {

            capsule.SetActive(false);
        
        }
    }
}
