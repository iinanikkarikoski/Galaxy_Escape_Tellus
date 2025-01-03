using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim2 : MonoBehaviour
{
    public Animator animator;
    public float animSpeed = 0.05f;

    void Start () {
        animator.speed = animSpeed;
    }

    void OnTriggerEnter(Collider player) {

        if (player.tag == "player 1" || player.tag == "player 2" || player.tag == "player 3"){
            animator.SetFloat("Open2", 1f);
        } else {
            animator.SetFloat("Open2", 0f);
        }
    }
}
