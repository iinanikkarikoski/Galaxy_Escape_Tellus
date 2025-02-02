using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim1 : MonoBehaviour
{
    public Animator animator;
    public float animSpeed = 0.05f;
    //public HueLamp hueLamp;

    void Start () {
        animator.speed = animSpeed;
    }

    void OnTriggerEnter(Collider player) {

        if (player.tag == "player 1" || player.tag == "player 2" || player.tag == "player 3"){
            animator.SetFloat("Open", 1f);
            //hueLamp.BossBattle();
        } else {
            animator.SetFloat("Open", 0f);
        }
    }
}
