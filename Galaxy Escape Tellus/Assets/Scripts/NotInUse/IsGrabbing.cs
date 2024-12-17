using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrabbing : MonoBehaviour
{
    public bool isGrabbing = false;
    
    public void setTrue(){
        isGrabbing = true;
    }
    public void setFalse(){
        isGrabbing = false;
    }
}
