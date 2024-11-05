using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    public float speed = 5f;
    private float _currentVelocity;
    private float smoothTime = 0.25f;
    public GameObject gameBoard;
   public void movePlayer1(){
        Debug.Log(this.tag);
        if(TiltFive.Input.TryGetStickTilt(	out Vector2 stickTilt,TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.Three)){
            Vector3 movementDirection = new Vector3(stickTilt.x * speed, 0, stickTilt.y * speed);
            this.transform.Translate(movementDirection, Space.World);
            Debug.Log("pitäis liikkua");
            var targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            this.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            gameBoard.transform.position = this.transform.position;
        }
    


    

   }
}
