using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAreaLight : MonoBehaviour
{
    public HueLamp hueLamp;

    public GameObject barrier;

    void OnTriggerEnter(Collider player) 
    {
        if (player.tag == "player 1" || player.tag == "player 2" || player.tag == "player 3") {
            hueLamp.NewArea();
            barrier.SetActive(false);
        }
    }
}
