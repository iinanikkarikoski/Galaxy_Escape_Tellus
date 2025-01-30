using UnityEngine;
using System.Collections; 
public class BossAnimation : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;
    public BossHit bossHitScript; // Reference to the BossHit script
    private SkinnedMeshRenderer bossRenderer;
    public Shader ghostShader; // Assign ghost shader in Inspector
    private bool hasDied = false; // Prevent multiple shader changes

    void Start()
    {
        // Get the Animator component attached to the alien
        animator = GetComponent<Animator>();
        bossRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

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
        //if (Input.GetKeyDown(KeyCode.F) && !hasDied)
        if (bossHitScript.bossHealth <= 0 && !hasDied)
        {
            // Trigger the dying animation immediately
            hasDied = true; // Prevents multiple executions
            animator.SetTrigger("DieTrigger");
            StartCoroutine(ChangeToGhostShader()); // Start shader change
        }
    }

    IEnumerator ChangeToGhostShader()
    {
        yield return new WaitForSeconds(2f); // Wait for animation to finish
        bossRenderer.material.shader = ghostShader; // Change shader to ghost effect
    }
}
