using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitFrameRate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 20;
        
    }

    
}
