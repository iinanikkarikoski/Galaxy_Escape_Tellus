using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableZone : MonoBehaviour
{
    public GameObject obj;
    

    private void OnTriggerStay(Collider collision){
        if (collision.gameObject.tag == "grabbable"){
            obj.SetActive(true);
        }
       
    }
}
