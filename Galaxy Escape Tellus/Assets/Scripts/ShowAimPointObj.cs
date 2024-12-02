using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowAimPointObj : MonoBehaviour
{
    public GameObject drawingSphereP1; //sphere for p1
    public GameObject flashLightP2; // light for p2
    public GameObject cubeP3; // placeholder object for p3

    public checkPosition checkPosition;
    private bool wasPressed_P1 = false;
    public Vector3[] positions;

    private TrailRenderer tr;
    private float triggerDisplacement;

    public bool enableCheckingP1 = false;
    public TMP_Text myTextP1;
    private bool circleDetected = false;
    public AudioSource audioSource;
    private bool audioPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        tr = drawingSphereP1.GetComponent<TrailRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
            if(triggerDisplacement > 0.5f){
                drawingSphereP1.SetActive(true);
                wasPressed_P1 = true;
            } else {
                drawingSphereP1.SetActive(false);
                if (wasPressed_P1 == true && enableCheckingP1 == true) {
                    Debug.Log("Checking shape...");
                    positions = new Vector3[tr.positionCount];
                    tr.GetPositions(positions); //get trace positions

                    //check shape
                    tr.GetPositions(positions); //get trace positions
                    if (circleDetected == true) {
                        // circle has been drawn, check line
                        if(checkPosition.IsLine(new List<Vector3>(positions))) {
                            Debug.Log("Line detected!!!!");
                            myTextP1.text = "Line detected, Good job!!";
                            if(audioPlayed == false) {
                                audioSource.Play();
                                audioPlayed = true;
                            }
                        } else {
                        Debug.Log("not a line");
                    }
                    }
                    else if (checkPosition.IsCircle(new List<Vector3>(positions)))
                    {
                        Debug.Log("Circle shape detected!!!!!!!!!!--------");
                        myTextP1.text = "Circle detected, Good job!!, now draw a line";
                        circleDetected = true;
                    } else {
                        Debug.Log("not a circle");
                    }
                }
                wasPressed_P1 = false;
                //display if shape accepted
                //sleep 1s
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
