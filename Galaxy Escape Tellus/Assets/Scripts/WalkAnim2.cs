using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnim2 : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if(TiltFive.Input.TryGetStickTilt(out Vector2 stickTilt, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Two)) {
            if (stickTilt != Vector2.zero) {
                //start animation
                animator.SetFloat("Walk", 1f);
            }
            else {
                //stop animation
                animator.SetFloat("Walk", 0f);
            }
        } 
    }
}
