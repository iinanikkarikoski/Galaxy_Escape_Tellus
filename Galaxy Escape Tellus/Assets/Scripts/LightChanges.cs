using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanges : MonoBehaviour
{

    public Light pointLight; 
    public Color greenColor = Color.green; 
    public Color redColor = Color.red; 
    public float flashDuration = 0.7f; 

    void Start()
    {
        // Ensure the light starts as red
        if (pointLight != null)
        {
            pointLight.color = redColor;
        }
        else
        {
            Debug.LogError("Point Light is not assigned.");
        }
        
    }

    public System.Collections.IEnumerator FlashLight()
    {
        if (pointLight != null)
        {
            // Change the light to green
            pointLight.color = greenColor;

            // Wait for the specified duration
            yield return new WaitForSeconds(flashDuration);

            // Revert the light back to red
            pointLight.color = redColor;
        }
    }

    public void FinishedLight()
    {
        if (pointLight != null)
        {
            pointLight.color = greenColor;
        }
    }
}
