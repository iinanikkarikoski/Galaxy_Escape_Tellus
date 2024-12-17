using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class newInputSystem : MonoBehaviour
{
    public GameObject cube;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("player_cube");
    }

    void OnMove(InputValue value){
        cube.transform.Translate(value.Get<Vector2>().x * Time.deltaTime * speed, 0.0f, value.Get<Vector2>().y * Time.deltaTime * speed);

    }
}
