using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Teleportplayers : MonoBehaviour
{
    public GameObject gameBoard1;
    public GameObject gameBoard2;
    public GameObject gameBoard3;
    public Vector3 startScreen = new Vector3(-60, 0, 0);
    public Vector3 endScreen = new Vector3(-90, 0, 0);
    public GameObject chair;

    private bool timeEnded = false;

    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    private float blink_timer;
    public Light light_galaxy;
    public Light light_horizon;

    //public Text timeText;
    public TMP_Text timer_text;
    public TMP_Text timer_text2;
    //public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        //timer.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.One, out bool buttonDown, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
            if (buttonDown){
                gameBoard1.transform.position = startScreen+ new Vector3(0, 0, 2);
                gameBoard2.transform.position = startScreen- new Vector3(7, 0, 0);
                gameBoard3.transform.position = startScreen+ new Vector3(0, 0, -2);
                chair.transform.position = new Vector3(8.4041996f ,0.189820006f ,0.356999993f);
                chair.transform.eulerAngles = new Vector3(0, 180, 0);
                timerIsRunning = true;
            }
            if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                if(timeRemaining <= 5){
                    blink_timer += Time.deltaTime;
                    if (blink_timer > 0.5f){
                        light_galaxy.enabled = !light_galaxy.enabled;
                        light_horizon.enabled = !light_horizon.enabled;
                        blink_timer -= 0.5f;
                    }
                }
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                
                timeRemaining = 0;
                timerIsRunning = false;
                gameBoard1.transform.position = endScreen + new Vector3(0, 0, 2);
                gameBoard2.transform.position = endScreen;
                gameBoard3.transform.position = endScreen+ new Vector3(0, 0, -2);
                timeEnded = true;


                 
            }
            
        }
            
            }
            /*
        if(TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.Two, out bool buttonDown2, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
                    if (buttonDown2){
                        //Debug.Log("jotain");
                        StartAgain();
                    }
                 }*/
    }
////////
//https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/    

    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer_text.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
        timer_text2.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    void StartAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
