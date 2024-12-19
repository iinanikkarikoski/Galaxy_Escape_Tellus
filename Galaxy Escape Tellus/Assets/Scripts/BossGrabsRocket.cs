using UnityEngine;

public class BossGrabsRocket : MonoBehaviour
{
    public Transform hand;  // Reference to the hand or claw of the alien
    public GameObject rocket;  // Reference to the object to be grabbed

    public void OnGrab()
    {
        if (rocket != null && hand != null)
        {
            // Save the current world rotation of the object
            Quaternion originalRotation = rocket.transform.rotation;

            // Parent the object to the hand
            rocket.transform.SetParent(hand);

            // Restore the object's world rotation
            rocket.transform.rotation = originalRotation;
        }
    }

}
