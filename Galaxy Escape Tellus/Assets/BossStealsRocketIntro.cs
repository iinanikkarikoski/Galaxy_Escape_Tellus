using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Animator animator;
    public ShowInstructions controlScript;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (controlScript.scriptOn)
        {
            //Debug.Log("anim changed");
            animator.SetBool("StartAnim", true);
            controlScript.scriptOn = false; // Prevent retriggering
        }
    }
}