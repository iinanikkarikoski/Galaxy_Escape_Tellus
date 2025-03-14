using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyDoorAnimation : MonoBehaviour
{
    public Animator animator;
    public float animSpeed = 0.05f;

    void Start () {
        animator.speed = animSpeed;
    }

    void OnTriggerEnter(Collider player) {

        if (player.tag == "player 1" || player.tag == "player 2" || player.tag == "player 3"){
            animator.SetFloat("Open", 1f);
            StartCoroutine(Close());
        } else {
            animator.SetFloat("Open", 0f);
        }
    }

    IEnumerator Close() {
        
        yield return new WaitForSeconds(8);
        animator.SetFloat("Open", 2f);
    }
}
