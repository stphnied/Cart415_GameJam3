using System.Collections;
using UnityEngine;
using TMPro;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI mainTextComponent;
    public string[] lines;
    public float textSpeed;
    private bool choicesDisplayed = false;

    void Start()
    {
        mainTextComponent.text = string.Empty;
        StartCoroutine(ShowDialogues());
    }

    void Update()
    {
        // Optionally, you can add logic here for player input or interaction if needed
        if (choicesDisplayed && Input.GetKeyDown(KeyCode.Alpha1))
        {
            HandleChoice(1);
        }
        else if (choicesDisplayed && Input.GetKeyDown(KeyCode.Alpha2))
        {
            HandleChoice(2);
        }
    }

    IEnumerator ShowDialogues()
    {
        yield return StartCoroutine(ShowDialogue("Assets/1.txt"));
        yield return StartCoroutine(ShowDialogue("Assets/2.txt"));
        yield return StartCoroutine(ShowDialogue("Assets/3.txt"));
        DisplayChoices();
    }

    IEnumerator ShowDialogue(string filePath)
    {
        string[] dialogueLines = File.ReadAllLines(filePath);

        foreach (string line in dialogueLines)
        {
            yield return TypeLine(line);
        }

       
        if (filePath == "Assets/4.txt")
        {
            yield return new WaitForSeconds(1f); 
            StartCoroutine(ShowDialogue("Assets/6.txt"));
        }
        if (filePath == "Assets/5.txt")
        {
            yield return new WaitForSeconds(1f); 
            StartCoroutine(ShowDialogue("Assets/6.txt"));
        }
        // Check if the displayed dialogue is "6.txt" and show "7.txt" afterward
        else if (filePath == "Assets/6.txt")
        {
            yield return new WaitForSeconds(1f); 
            StartCoroutine(ShowDialogue("Assets/7.txt"));
        }
        else
        {
            yield return new WaitForSeconds(1f); 
        }
    }

    IEnumerator TypeLine(string line)
    {
        mainTextComponent.text = string.Empty;

        foreach (char c in line.ToCharArray())
        {
            mainTextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(1f); // Adjust this delay if needed
    }

    void DisplayChoices()
    {
        mainTextComponent.text = "1. V: an accident?! what happened\n2. V: two months?!?";
        choicesDisplayed = true;
    }

    void HandleChoice(int choice)
    {
        // Reset the choicesDisplayed flag after handling the choice
        choicesDisplayed = false;

        switch (choice)
        {
            case 1:
                // Handle the choice for "V: an accident?! what happened"
                StartCoroutine(ShowDialogue("Assets/4.txt")); 
                break;
            case 2:
                // Handle the choice for "V: two months?!?"
                StartCoroutine(ShowDialogue("Assets/5.txt")); 
                break;
            default:
                break;
        }
    }
}
