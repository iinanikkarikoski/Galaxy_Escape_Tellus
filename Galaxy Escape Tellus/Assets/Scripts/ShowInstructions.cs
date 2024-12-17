using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class ShowInstructions : MonoBehaviour
{
    public TextMeshProUGUI DialogueTextP1; // Reference to the UI text element
    public TextMeshProUGUI DialogueTextP2; // Reference to the UI text element
    public TextMeshProUGUI DialogueTextP3; // Reference to the UI text element

    public string[] SentencesP1;          // Array of sentences to display
    public string[] SentencesP2;          // Array of sentences to display
    public string[] SentencesP3;          // Array of sentences to display

    private int IndexP1 = 0;              // Index of the current sentence
    private int IndexP2 = 0;              // Index of the current sentence
    private int IndexP3 = 0;              // Index of the current sentence

    public float DialogueSpeed;         // Speed of the text writing
    public int delayBetweenSentences = 6000;

    public GameObject instructionsPlane1; // Reference to the instruction plane
    //public GameObject collectionsPlane1; // Reference to the collections plane
    private bool hasActivated = false;    // To ensure the plane shows only once
    private bool isLastSentence = false;

/*
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
            isLastSentence = true;
        }
    }
*/
    IEnumerator WriteSentenceP1()
    {
        foreach (char Character in SentencesP1[IndexP1].ToCharArray())
        {
            DialogueTextP1.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        IndexP1++;
    }
    IEnumerator WriteSentenceP2()
    {
        foreach (char Character in SentencesP2[IndexP2].ToCharArray())
        {
            DialogueTextP2.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        IndexP2++;
    }
    IEnumerator WriteSentenceP3()
    {
        foreach (char Character in SentencesP3[IndexP3].ToCharArray())
        {
            DialogueTextP3.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        IndexP3++;
    }

    async void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("player 1") || other.CompareTag("player 2") || other.CompareTag("player 3") ) && !hasActivated)
        {
            hasActivated = true; // Ensure the plane shows only once

            if (instructionsPlane1 != null)
            {
                instructionsPlane1.SetActive(true); // Activate the instruction plane
                //if (isLastSentence == false) {
                for (int  i = 0; i < SentencesP1.Length; i++) {

                    DialogueTextP1.text = "";
                    StartCoroutine(WriteSentenceP1());

                    DialogueTextP2.text = "";
                    StartCoroutine(WriteSentenceP2());

                    DialogueTextP3.text = "";
                    StartCoroutine(WriteSentenceP3());

                    await Task.Delay(delayBetweenSentences);
                }
            }
            else
            {
                Debug.LogError("Instruction Plane is not assigned!");
            }
        }
        /*
        if (other.CompareTag("player 2") && !hasActivated)
        {
            hasActivated = true; // Ensure the plane shows only once

            if (instructionsPlane1 != null)
            {
                instructionsPlane1.SetActive(true); // Activate the instruction plane
                //if (isLastSentence == false) {
                for (int  i = 0; i < SentencesP2.Length; i++) {
                    //NextSentence();
                    DialogueTextP2.text = "";
                    StartCoroutine(WriteSentenceP2());
                    //Thread.Sleep(3000);
                    await Task.Delay(delayBetweenSentences);
                }
            }
            else
            {
                Debug.LogError("Instruction Plane is not assigned!");
            }
        }
        if (other.CompareTag("player 3") && !hasActivated)
        {
            hasActivated = true; // Ensure the plane shows only once

            if (instructionsPlane1 != null)
            {
                instructionsPlane1.SetActive(true); // Activate the instruction plane
                //if (isLastSentence == false) {
                for (int  i = 0; i < SentencesP3.Length; i++) {
                    //NextSentence();
                    DialogueTextP3.text = "";
                    StartCoroutine(WriteSentenceP3());
                    //Thread.Sleep(3000);
                    await Task.Delay(delayBetweenSentences);
                }
            }
            else
            {
                Debug.LogError("Instruction Plane is not assigned!");
            }
        }*/
    }
}
