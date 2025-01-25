using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;
    public BossHit bossHitScript; // Reference to the BossHit script

    void Start()
    {
        // Get the Animator component attached to the alien
        animator = GetComponent<Animator>();

        // Ensure the alien starts with the walking animation
        //animator.Play("walkingAnim");
        if (bossHitScript == null)
        {
            bossHitScript = GameObject.Find("Boss").GetComponent<BossHit>();
        }
    }

    void Update()
    {
        // Check if the "F" key is pressed
        //if (Input.GetKeyDown(KeyCode.F))
        if (bossHitScript.bossHealth <= 0)
        {
            // Trigger the dying animation immediately
            animator.SetTrigger("DieTrigger");
        }
    }
}
