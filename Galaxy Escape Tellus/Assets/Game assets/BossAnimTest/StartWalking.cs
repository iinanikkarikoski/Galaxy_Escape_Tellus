using UnityEngine;

public class StartWalking : MonoBehaviour
{
    public Animator alienAnimator; // Reference to the Animator component

    void Update()
    {
        // Check if the "K" key is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Toggle the "isWalking" parameter
            if (alienAnimator != null)
            {
                bool isWalking = alienAnimator.GetBool("isWalking");
                alienAnimator.SetBool("isWalking", !isWalking);
            }
            else
            {
                Debug.LogError("Animator component is not assigned!");
            }
        }
    }
}
