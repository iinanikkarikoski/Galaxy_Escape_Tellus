using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHit : MonoBehaviour
{

    private int bossHealth = 100;
    public GameObject boss;
    public GameObject bridge;

    public Image progressbar;

    // Start is called before the first frame update
    void Start()
    {
        bridge.SetActive(false);
        progressbar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "bullet") {
            bossHealth -= 20;
            progressbar.fillAmount -= 0.2f;

            Debug.Log("Boss healt = " + bossHealth);

            if (bossHealth <= 0) {
                Debug.Log("Boss defeated!");
                //boss.SetActive(false);
                bridge.SetActive(true);
            }
        }
    }
}
