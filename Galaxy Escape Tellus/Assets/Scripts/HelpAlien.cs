using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelpAlien : MonoBehaviour
{
    public TMP_Text myText;
    public ShowAimPointObj showAimPointObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        myText.text = "Can you please help me? Draw a circle etc.";
        showAimPointObj.enableCheckingP1 = true;
    }
}
