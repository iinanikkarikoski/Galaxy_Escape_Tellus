using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableShapeRecognition : MonoBehaviour
{
    public ShowPencil showPencil;

    void OnTriggerEnter(Collider player)
    {
        showPencil.enableCheckingP1 = true;
    }
}
