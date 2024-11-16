using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAimPointObj : MonoBehaviour
{
    public GameObject drawingSphereP1; //sphere for p1
    public GameObject flashLightP2; // light for p2
    public GameObject cubeP3; // placeholder object for p3

    private TrailRenderer tr;
    private float triggerDisplacement;
    // Start is called before the first frame update
    void Start()
    {
        tr = drawingSphereP1.GetComponent<TrailRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {/*
        if(TiltFive.Input.TryGetButton(TiltFive.Input.WandButton.One, out bool buttonDown, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
            if (buttonDown){
                obj.SetActive(true);
                //tr.GetPosition(0);
            } else {
                obj.SetActive(false);
                tr.Clear();
            }
        }*/
        if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
            if(triggerDisplacement > 0.5f){
                drawingSphereP1.SetActive(true);
            } else {
                drawingSphereP1.SetActive(false);
                tr.Clear();
            }
        }
        if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Two)) {
            if(triggerDisplacement > 0.5f){
                flashLightP2.SetActive(true);
            } else {
                flashLightP2.SetActive(false);
            }
        }
        if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Three)) {
            if(triggerDisplacement > 0.5f){
                cubeP3.SetActive(true);
            } else {
                cubeP3.SetActive(false);
            }
        }
    }
}
