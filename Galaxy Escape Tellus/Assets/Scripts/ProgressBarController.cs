using UnityEngine;
using UnityEngine.UI; // For UI elements like Slider

public class ProgressBarController : MonoBehaviour
{
    public Slider progressBar;  // Reference to the progress bar (Slider)
    private int collectedSensors = 0;  // Counter for collected sensors
    private int maxSensors = 10;  // Max sensors to collect

    void Update()
    {
        // Check if the "A" key is pressed and ensure collectedSensors doesn't exceed maxSensors
        if (Input.GetKeyDown(KeyCode.A) && collectedSensors < maxSensors)
        {
            CollectSensor();
            Debug.Log("a pressed");
        }
    }

    public void CollectSensor()
    {
        // Increment collectedSensors if it's less than the max limit
        if (collectedSensors < maxSensors)
        {
            collectedSensors++;
            UpdateProgressBar();
        }
    }

    void UpdateProgressBar()
    {
        // Update the slider's value based on collectedSensors
        progressBar.value = collectedSensors;

        // Optional: Log progress to the console (can be helpful for debugging)
        Debug.Log("Collected " + collectedSensors + "/" + maxSensors + " sensors");
    }

    // Optional: Start the progress bar at 0
    void Start()
    {
        progressBar.value = 0;
    }
}
