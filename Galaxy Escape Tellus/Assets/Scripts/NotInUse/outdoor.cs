using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outdoor : MonoBehaviour
{
    //private bool floating = false;
    //private GameObject player;
    public GameObject pl1;
    public GameObject pl2;
    public GameObject pl3;

    public GameObject obj;

    

    private static bool player1 = false;
    private static bool player2 = false;
    private static bool player3 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 && player2 && player3){
            pl1.transform.position += new Vector3(0.005f, 0.005f, 0.005f);
            pl2.transform.position += new Vector3(-0.005f, 0.005f, 0.005f);
            pl3.transform.position += new Vector3(0.005f, 0.005f, -0.005f);
            obj.SetActive(true);
        }
            

        
        
    }

    

    private void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag == "player 1"){
            player1 = true;
            collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
            
        }
        if (collision.gameObject.tag == "player 2"){
            player2 = true;
            collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if (collision.gameObject.tag == "player 3"){
            player3 = true;
            collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    
}
