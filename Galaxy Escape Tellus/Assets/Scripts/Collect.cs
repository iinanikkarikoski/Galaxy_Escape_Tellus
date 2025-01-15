using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{
    public TMP_Text myText1;
    public TMP_Text myText2;
    public TMP_Text myText3;
    public static int collected;

    private GameObject barrier;

    //public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = this.GetComponent<AudioSource>();
        barrier = GameObject.Find("area 2 collider");
        
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "player 1" || player.tag == "player 2" || player.tag == "player 3"){
            //audioSource.Play();
            this.gameObject.SetActive(false);

            collected += 1;
            string collectedString = "Collected: " + collected.ToString() + "/10 sensors";
            myText1.text = collectedString;
            myText2.text = collectedString;
            myText3.text = collectedString;

            if (collected >= 3) {
                barrier.SetActive(false);
            }
        }
    }
    public int getCollected(){
        return collected;
    }
}