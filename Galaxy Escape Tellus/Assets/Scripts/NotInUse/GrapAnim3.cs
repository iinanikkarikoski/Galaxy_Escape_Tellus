using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapAnim3 : MonoBehaviour
{
    public Animator animator;
    private float triggerDisplacement;

    void Update()
    {
        if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Three)) {
            if(triggerDisplacement > 0.5f){
                animator.SetFloat("Grab", triggerDisplacement);
            }
            else
            {
                triggerDisplacement = 0;
                animator.SetFloat("Grab", triggerDisplacement);
            }
        }
    }
}
