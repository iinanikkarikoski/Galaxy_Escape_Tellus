using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour

{
    
    public GameObject magnifyingGlassCamera;
    public Camera mainCamera;
    private float fixedRotation = 0;
    
    void Start()
    {
        Debug.Log(TiltFive.Glasses.IsConnected(TiltFive.PlayerIndex.Three));
        if (TiltFive.Glasses.IsConnected(TiltFive.PlayerIndex.Three)) {
            mainCamera = TiltFive.Glasses.GetLeftEye(TiltFive.PlayerIndex.Three); 
        }
          
    }

    void Update()
    {
        if (mainCamera) {
            Vector3 mainCamRotation = mainCamera.transform.eulerAngles;
            magnifyingGlassCamera.transform.eulerAngles = new Vector3(mainCamRotation.x,  mainCamRotation.y, fixedRotation);

        }
        
    }
}