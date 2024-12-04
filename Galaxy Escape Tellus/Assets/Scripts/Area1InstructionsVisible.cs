using UnityEngine;

public class Area1InstructionsVisible : MonoBehaviour
{
    public GameObject collectiblesPlane1; 
    //public GameObject collectiblesPlane2;
    //public GameObject collectiblesPlane3;
    public GameObject instructionsPlane1;
    //public GameObject instructionsPlane2;
    //public GameObject instructionsPlane3;

    private bool hasActivated1 = false; // To track if the plane has already been shown
    //private bool hasActivated2 = false; // To track if the plane has already been shown
    //private bool hasActivated3 = false; // To track if the plane has already been shown

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("player 1") && !hasActivated1)
        {
            hasActivated1 = true;
            // Activate the instruction plane
            if (collectiblesPlane1 != null)
            {
                collectiblesPlane1.SetActive(true);
                // tähän jotain että kun kaikki kerätty niin pois päältä
            }
            else
            {
                Debug.LogError("Instruction Plane is not assigned!");
            }
            if (instructionsPlane1 != null)
            {
                instructionsPlane1.SetActive(true); // Activate the instruction plane
                //instructionsPlane1.SetActive(false); jotain tähän että milloin menee pois päältä
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
