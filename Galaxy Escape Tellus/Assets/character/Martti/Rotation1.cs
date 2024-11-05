using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation1 : MonoBehaviour
{
    //public Transform centerPoint;
    //public float speed = 20.0f;
    public Vector3 rotation;

    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
        //centerPoint.RotateAround(Vector3.up * speed * Time.deltaTime);
        //centerPoint.RotateAround(centerPoint.position, Vector3.up, speed * Time.deltaTime);
        //planet.Rotate(transform.up, speed * Time.deltaTime);
        /*foreach (Transform child in transform)
        {
            child.RotateAround(centerPoint.position, Vector3.up, speed * Time.deltaTime);
        }*/
    }
}
