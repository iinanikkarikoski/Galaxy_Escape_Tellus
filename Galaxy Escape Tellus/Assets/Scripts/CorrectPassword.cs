using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectPassword : MonoBehaviour
{
    private int[] result, correctCombination;
    //public GameObject doorGalaxy;
    //public GameObject doorHorizon;
    public GameObject bossDoorCollider;

    //[SerializeField] private AudioClip winSound;
    //[SerializeField] private AudioSource audioSource;

    private void Start()
    {
        result = new int[]{5,5,5,5};
        correctCombination = new int[] { 1,0,3,2 };
        LockControlTest.Rotated += CheckResults;
    }
    /*
    public void SetPassword1(string sensor1){
        char[] numbers1 = sensor1.ToCharArray();
        
        char secondNumberChar = numbers1[0];
        double secondNumberDouble = char.GetNumericValue(secondNumberChar);
        int number2Final = (int)secondNumberDouble;

        char fourthNumberChar = numbers1[2];
        double fourthNumberDouble = char.GetNumericValue(fourthNumberChar);
        int number4Final = (int)fourthNumberDouble;


        correctCombination[1] = number2Final;
        correctCombination[3] = number4Final;
        Debug.Log(correctCombination);
    }

    public void SetPassword2(string sensor2){
        char[] numbers2 = sensor2.ToCharArray();

        char firstNumberChar = numbers2[1];
        double firstNumberDouble = char.GetNumericValue(firstNumberChar);
        int number1Final = (int)firstNumberDouble;


        char thirdNumberChar = numbers2[2];
        double thirdNumberDouble = char.GetNumericValue(thirdNumberChar);
        int number3Final = (int)thirdNumberDouble;



        correctCombination[0] = number1Final;
        correctCombination[2] = number3Final;
        Debug.Log(correctCombination);
    }
*/
    private void CheckResults(string wheelName, int number)
    {   //Debug.Log(number);
        //Debug.Log("password script");
        switch (wheelName)
        {
            //
            case "Ruller1":
                result[0] = number;
                break;

            case "Ruller2":
                result[1] = number;
                break;

            case "Ruller3":
                result[2] = number;
                break;

            case "Ruller4":
                result[3] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            Debug.Log("Opened!");
            bossDoorCollider.SetActive(false);
            //doorGalaxy.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            //doorGalaxy.transform.position += new Vector3(1, 0, -1);

            //doorHorizon.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            //doorHorizon.transform.position += new Vector3(1, 0, -1);

            //win sound
            //audioSource.PlayOneShot(winSound);

            //if(TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.Two, out bool buttonDown2, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
            //    if (buttonDown2){
            //        StartAgain();
            //    }
            //}




        }
    }

    private void StartAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        LockControlTest.Rotated -= CheckResults;
    }
}
