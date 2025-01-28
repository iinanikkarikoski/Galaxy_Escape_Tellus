using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet1 : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    private float triggerDisplacement;
    private bool wasPressed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Fire();
        }
            
        /*if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
            if(triggerDisplacement > 0.5f){
                if(wasPressed == false){
                    Fire();
                }
                wasPressed = true;
            } else {
                wasPressed = false;
            }
        }*/
    }

    public void Fire() {
 
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 1);
    }
}
