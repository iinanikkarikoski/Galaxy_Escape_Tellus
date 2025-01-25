using UnityEngine;

public class RocketStaysUp : MonoBehaviour
{
    public Animator animator;          // Reference to the Animator
    private Vector3 finalPosition;     // Store the final position of the rocket

    void Start()
    {
        // Store the final position of the rocket before the animation starts
        finalPosition = transform.position;
    }

    void Update()
    {
        // Check if the animation has finished (assuming it's a one-shot animation with no looping)
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RocketTakesOff") &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            // Lock the rocket at its final position
            transform.position = finalPosition;
        }
    }
}
