using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wand_Movement : MonoBehaviour
{
    public float speed = 5f;
    private float _currentVelocity;
    private float smoothTime = 0.25f;
    public GameObject gameBoard;
    

    public void MoveCube(InputAction.CallbackContext context) {
        float singleStep = speed * Time.deltaTime;
        Vector3 movementDirection = new Vector3(context.ReadValue<Vector2>().x * speed, 0, context.ReadValue<Vector2>().y * speed);
        
        //movementDirection.Normalize();
        //Debug.Log(movementDirection);
        this.transform.Translate(movementDirection, Space.World);

        //if(movementDirection != Vector3.zero){

        var targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        this.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        
        
        gameBoard.transform.position = this.transform.position;

        


            //var targetRotation = Quaternion.LookRotation(movementDirection);
            //this.transform.GetChild(0).localRotation = targetRotation;
            //this.transform.forward = movementDirection;
            //Vector3 newDirection = Vector3.RotateTowards(.forward, movementDirection, singleStep, 0.0f);
            //this.transform.rotation = Quaternion.LookRotation(newDirection);
            //Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, toRotation, singleStep);
        //}
        
    }

    
}
