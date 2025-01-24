using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the alien
        animator = GetComponent<Animator>();

        // Ensure the alien starts with the walking animation
        animator.Play("walkingAnim");
    }

    void Update()
    {
        // Check if the "D" key is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Trigger the dying animation immediately
            animator.SetTrigger("DieTrigger");
        }
    }
}
