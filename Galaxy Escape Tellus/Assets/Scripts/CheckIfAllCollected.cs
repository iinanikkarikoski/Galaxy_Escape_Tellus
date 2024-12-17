using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckIfAllCollected : MonoBehaviour
{
    public Collect collect;
    public GameObject barrier;
    //public TMP_Text myText;
    

    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "player 1" || player.gameObject.tag == "player 2" || player.gameObject.tag == "player 3"){
            if(collect.getCollected() == 3){
                barrier.SetActive(false);
                //Debug.Log("New area unlocked!");
            }//else{
             //   myText.text = "Make sure you collected enough magic cubes.";
            //}
        }
        
    }

    //void OnTriggerExit(Collider player)
    //{
    //    if (player.tag == "Player"){
            
    //        myText.text = "";

    //    }
    //}
}
