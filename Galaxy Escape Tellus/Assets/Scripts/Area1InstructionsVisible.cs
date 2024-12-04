using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText; // Reference to the UI text element
    public string[] Sentences;          // Array of sentences to display
    private int Index = 0;              // Index of the current sentence
    public float DialogueSpeed;         // Speed of the text writing

    public GameObject instructionsPlane1; // Reference to the instruction plane
    public GameObject collectionsPlane1; // Reference to the collections plane
    private bool hasActivated = false;    // To ensure the plane shows only once

    void Update()
    {
        // Handle dialogue progression
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        if (Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        // If it's the last sentence, hide the instruction plane
        if (Index == Sentences.Length - 1 && instructionsPlane1 != null)

        // If we are past the last sentence, hide the instruction plane
        // if (instructionsPlane1 != null)
        {
            instructionsPlane1.SetActive(false);
        }
    }

    IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        Index++;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !hasActivated)
        {
            hasActivated = true; // Ensure the plane shows only once

            if (instructionsPlane1 != null)
            {
                instructionsPlane1.SetActive(true); // Activate the instruction plane
            }
            else
            {
                Debug.LogError("Instruction Plane is not assigned!");
            }
        }
    }
}
