using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

//source: https://discussions.unity.com/t/simple-timer/56201/3

    public int duration = 60;
    public int timeRemaining;
    public bool isCountingDown = false;
    private bool start = false;

    public TMP_Text timer_text;

    public GameObject gameBoard1;
    public GameObject gameBoard2;
    public GameObject gameBoard3;
    public Vector3 endScreen = new Vector3(-90, 0, 0);

    public void Start()
    {
        //Debug.Log("jotain1");
        if (!isCountingDown) {
            //Debug.Log("jotain");
            isCountingDown = true;
            timeRemaining = duration;
            Invoke ( "_tick", 1f );
        }
    }
    public void setStart(){
        start = true;
    }

    private void _tick() {
        //if (start){
            timeRemaining--;
            timer_text.SetText(timeRemaining.ToString());
            if(timeRemaining > 0) {
                Invoke ( "_tick", 1f );
            } else {
                Debug.Log("you die :( ");
                
                isCountingDown = false;
                gameBoard1.transform.position = endScreen;
                gameBoard2.transform.position = endScreen;
                gameBoard3.transform.position = endScreen;
            }
        //}
    }
}
