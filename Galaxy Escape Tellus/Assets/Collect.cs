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
    //public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = this.GetComponent<AudioSource>();
        
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "player 1" || player.tag == "player 2" || player.tag == "player 3"){
            //audioSource.Play();
            this.gameObject.SetActive(false);

            collected += 1;
            myText1.text = collected.ToString();
            myText2.text = collected.ToString();
            myText3.text = collected.ToString();
        }
    }
    public int getCollected(){
        return collected;
    }
}