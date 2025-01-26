using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f;
    private float _currentVelocity;
    private float smoothTime = 0.25f;
    public GameObject gameBoard;
    private TiltFive.PlayerIndex playerIndex;
    void Start(){
        if (this.tag == "player 1"){
            gameBoard = GameObject.Find("Tilt Five Game Board 1");
        } else if (this.tag == "player 2"){
            gameBoard = GameObject.Find("Tilt Five Game Board 2");
        } else if (this.tag == "player 3"){
            gameBoard = GameObject.Find("Tilt Five Game Board 3");
        }
        
    }
   public void Update(){

    if (this.tag == "player 1"){
        playerIndex = TiltFive.PlayerIndex.One;
    } else if (this.tag == "player 2"){
        playerIndex = TiltFive.PlayerIndex.Two;
    } else if (this.tag == "player 3"){
        playerIndex = TiltFive.PlayerIndex.Three;
    }
        
        if(TiltFive.Input.TryGetStickTilt(	out Vector2 stickTilt,TiltFive.ControllerIndex.Right, playerIndex)){
            //Debug.Log("player 1 tag tunnistettu");
            Vector3 movementDirection = new Vector3(stickTilt.x * speed, 0, stickTilt.y * speed);
            this.transform.Translate(movementDirection, Space.World);
            var targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            this.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            //gameBoard.transform.position.x = this.transform.position.x;
            //gameBoard.transform.position.y = this.transform.position.y;
            gameBoard.transform.position = new Vector3(this.transform.position.x, 10, this.transform.position.z);
        }
    //}
    //if (this.tag == "player 2"){
        /*
        if(TiltFive.Input.TryGetStickTilt(	out Vector2 stickTilt2,TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Two)){
            Debug.Log("player 2 tag tunnistettu");
            Vector3 movementDirection = new Vector3(stickTilt2.x * speed, 0, stickTilt2.y * speed);
            this.transform.Translate(movementDirection, Space.World);
            var targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            this.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            gameBoard.transform.position = this.transform.position;
        }
    //} 
    
    //if (this.gameObject.tag == "player 3"){
        
       if(TiltFive.Input.TryGetStickTilt(	out Vector2 stickTilt3,TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Three)){
            Debug.Log("player 3 tag tunnistettu");
            Vector3 movementDirection3 = new Vector3(stickTilt3.x * speed, 0, stickTilt3.y * speed);
            this.transform.Translate(movementDirection3, Space.World);
            //Debug.Log("pitäis liikkua");
            var targetAngle = Mathf.Atan2(movementDirection3.x, movementDirection3.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            this.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            gameBoard.transform.position = this.transform.position;
        }
    //}


    */

   }
}
