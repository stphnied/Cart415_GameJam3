using System.Collections;
using UnityEngine;
using TMPro;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI mainTextComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private string originalFilePath;
    private bool originalDialogueShown = false;

    void Start()
    {
        mainTextComponent.text = string.Empty;
        originalFilePath = "Assets/dialogue.txt";  // setting the original file path
        ReadDialogueFile(originalFilePath);
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        // Optionally, you can add logic here for player input or interaction if needed
    }

    void ReadDialogueFile(string filePath)
    {
        string[] dialogueLines = File.ReadAllLines(filePath);

        // the first line of the file is the main dialogue
        lines = dialogueLines;
    }

   IEnumerator TypeLine()
{
    // Clear the previous line before typing the new one
    mainTextComponent.text = string.Empty;

    foreach (char c in lines[index].ToCharArray())
    {
        mainTextComponent.text += c;
        yield return new WaitForSeconds(textSpeed);
    }

    yield return new WaitForSeconds(2f);

    NextLine();
}


    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            mainTextComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Check if the original dialogue has been shown
            if (!originalDialogueShown)
            {
                originalDialogueShown = true;
                mainTextComponent.text = string.Empty; // Clear the text before showing the next set

                // Show the next set of dialogues labeled numerically from 1 to 5
                StartCoroutine(ShowNextSets());
            }
        }
    }

    IEnumerator ShowNextSets()
    {
        for (int i = 1; i <= 10; i++)
        {
            string nextFilePath = $"Assets/{i}.txt";
            ReadDialogueFile(nextFilePath);
            index = 0; // Reset index for the new set
            yield return StartCoroutine(TypeLine());
            yield return new WaitForSeconds(2f); // Adjust the delay between sets
        }

        // After showing all sets, return to the original dialogue
        originalDialogueShown = false;
        ReadDialogueFile(originalFilePath);
        StartCoroutine(TypeLine());
    }
}
