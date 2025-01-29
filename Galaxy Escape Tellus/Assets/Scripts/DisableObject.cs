using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public float disableTime = 50f; // Time in seconds before disabling the GameObject

    void Start()
    {
        Invoke("DisableObject", disableTime);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}