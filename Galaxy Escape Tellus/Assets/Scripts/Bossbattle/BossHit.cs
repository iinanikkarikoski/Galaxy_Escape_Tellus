using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHit : MonoBehaviour
{

    public int bossHealth = 100;
    public GameObject boss;
    public GameObject bridge;

    public Image progressbar;
    public GameObject lavaColl;

    public LightChangesBB lightChanges;
    //public HueLampBB hueLamp;

    void Start()
    {
        bridge.SetActive(false);
        progressbar.fillAmount = 1;
        lavaColl.SetActive(true);
    }

    public void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "bullet") {
            bossHealth -= 10;
            progressbar.fillAmount -= 0.1f;

            Debug.Log("Boss healt = " + bossHealth);

            if (bossHealth > 0) {
                if (lightChanges != null /*&& hueLamp != null*/) {
                    //hueLamp.StartCoroutine(hueLamp.FlashLightHue());
                    lightChanges.StartCoroutine(lightChanges.FlashLight());
                }
            }
            
            if (bossHealth <= 0) {
                Debug.Log("Boss defeated!");
                bridge.SetActive(true);
                lavaColl.SetActive(false);

                if (lightChanges != null /*&& hueLamp != null*/) {
                    //hueLamp.FinishedLightHue();
                    lightChanges.FinishedLight();
                    
                }
            }
        }
    }
}
