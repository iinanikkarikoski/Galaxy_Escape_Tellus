using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBossBattle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //if (other.tag == "TellusExit")
        //{
        Debug.Log("to boss battle ---->");
        SceneManager.LoadScene("Bossbattle"); 
        //}
    }
}
