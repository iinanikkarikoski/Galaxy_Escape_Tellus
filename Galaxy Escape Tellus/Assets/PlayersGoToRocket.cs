using UnityEngine;

public class PlayersGoToRocket : MonoBehaviour
{
    // Reference to all the characters
    public GameObject[] characters; // Drag your 3 characters into this array in the Inspector
    public Animator animator;        // Reference to the Animator that will play the animation
    public string animationTrigger = "PlayAnimationTrigger"; // Trigger for the animation

    private bool allPlayersInvisible = false; // To check if all players are invisible

    void OnTriggerEnter(Collider other)
    {
        // Loop through the array of characters
        foreach (GameObject character in characters)
        {
            // Check if the object entering the trigger is one of the characters
            if (other.gameObject == character)
            {
                // Make the character invisible by disabling its Renderer
                Renderer[] renderers = character.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in renderers)
                {
                    renderer.enabled = false;
                }

                // Optional: Disable character collisions if needed
                Collider[] colliders = character.GetComponentsInChildren<Collider>();
                foreach (Collider collider in colliders)
                {
                    collider.enabled = false;
                }

                Debug.Log($"{character.name} has gone invisible!");
            }
        }

        // After making all players invisible, check if all players are invisible
        if (!allPlayersInvisible)
        {
            allPlayersInvisible = AreAllPlayersInvisible();

            // If all players are invisible, trigger the animation once
            if (allPlayersInvisible)
            {
                PlayAnimationOnce();
            }
        }
    }

    // Function to check if all players are invisible
    bool AreAllPlayersInvisible()
    {
        foreach (GameObject player in characters)
        {
            Renderer[] renderers = player.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                // If any renderer is enabled, the player is still visible
                if (renderer.enabled)
                {
                    return false;
                }
            }
        }
        return true; // All players are invisible
    }

    // Function to play the animation once
    void PlayAnimationOnce()
    {
        if (animator != null )
        {
            animator.SetTrigger(animationTrigger); // Trigger your animation
            Debug.Log("Animation triggered!");
        }
    }

    // PPOISTA!!
    void Update()
    {
        // Check if the "F" key is pressed
        //if (Input.GetKeyDown(KeyCode.F))
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetTrigger(animationTrigger); // Trigger your animation
            Debug.Log("Animation triggered!");
        }
    }
}
