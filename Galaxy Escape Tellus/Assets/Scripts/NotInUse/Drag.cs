using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drag : MonoBehaviour
{
    public GameObject obj;
    

    void OnTriggerStay(Collider collision) {
       

        if(collision.gameObject.tag == "grab 1") {
            float triggerDisplacement = 0f;
            if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
                if(triggerDisplacement > 0.5f){
                    
                    obj.transform.position = collision.gameObject.transform.position;
                }
                
                        
            }
        
        } 
        
        if(collision.gameObject.tag == "grab 2") {
            float triggerDisplacement = 0f;
            if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Two)) {
                if(triggerDisplacement > 0.5f){
                    obj.transform.position = collision.gameObject.transform.position;
                }
                        
            }
        
        }   
        if(collision.gameObject.tag == "grab 3") {
            float triggerDisplacement = 0f;
            if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Three)) {
                if(triggerDisplacement > 0.5f){
                    obj.transform.position = collision.gameObject.transform.position;
                }
                        
            }
        
        }          
    }
}

