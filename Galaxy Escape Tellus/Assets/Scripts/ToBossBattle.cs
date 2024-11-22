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

    private void onTriggerEnter(Collider other) {
        if (other.tag == "TellusExit")
        {
            SceneManager.LoadScene("Bossbattle"); 
        }
    }
}
