using UnityEngine;

public class Area1InstructionsVisible : MonoBehaviour
{
    public GameObject collectiblesPlane1; 
    
    //public GameObject collectiblesPlane2;
    //public GameObject collectiblesPlane3;
    public GameObject instructionsPlane1;
    //public GameObject instructionsPlane2;
    //public GameObject instructionsPlane3;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("player 1"))
        {
            // Activate the instruction plane
            if (collectiblesPlane1 != null)
            {
                collectiblesPlane1.SetActive(true);
            }
            else
            {
                Debug.LogError("Instruction Plane is not assigned!");
            }
            if (instructionsPlane1 != null)
            {
                instructionsPlane1.SetActive(true);
            }
            else
            {
                Debug.LogError("Instruction Plane is not assigned!");
            }
        }
        /*if (other.CompareTag("player 2"))
        {
            // Activate the instruction plane
            if (collectiblesPlane2 != null)
            {
                collectiblesPlane2.SetActive(true);
            }
            else
            {
                Debug.LogError("Instruction Plane is not assigned!");
            }
        }
        if (other.CompareTag("player 3"))
        {
            // Activate the instruction plane
            if (collectiblesPlane3 != null)
            {
                collectiblesPlane3.SetActive(true);
            }
            else
            {
                Debug.LogError("Instruction Plane is not assigned!");
            }
        }*/
    }
}
