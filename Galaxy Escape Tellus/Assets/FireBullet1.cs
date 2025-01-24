using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet1 : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    private float triggerDisplacement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Fire();
        }

        /*if(TiltFive.Input.TryGetTrigger(out triggerDisplacement, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One)) {
            Fire();
        }*/
    }

    public void Fire() {
 
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5);
    }
}
