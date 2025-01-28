using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangesBB : MonoBehaviour
{

    public Light pointLight; 
    public Color magentaColor = Color.magenta; 
    public Color cyanColor = Color.cyan; 
    public float flashDuration = 0.5f; 

    void Start()
    {
        // Ensure the light starts as cyan
        if (pointLight != null) {
            pointLight.color = cyanColor;
        }
        else {
            Debug.LogError("Point Light is not assigned.");
        }
        
    }

    public System.Collections.IEnumerator FlashLight()
    {
        if (pointLight != null)
        {
            // Change the light to magenta
            pointLight.color = magentaColor;

            // Wait for the specified duration
            yield return new WaitForSeconds(flashDuration);

            // Revert the light back to cyan
            pointLight.color = cyanColor;
        }
    }

    public void FinishedLight()
    {
        if (pointLight != null)
        {
            pointLight.color = magentaColor;
        }
    }
}
