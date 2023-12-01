using System.Collections;
using UnityEngine;
using TMPro;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    // Text component for displaying dialogue
    public TextMeshProUGUI mainTextComponent;
    public TextMeshProUGUI nameText;

    // Speed at which the text is typed on the screen
    public float textSpeed;

    // Flag to track whether choices are currently displayed
    private bool choicesDisplayed = false;

    // Variable to store the current dialogue file path
    private string currentDialogue;


    void Start()
    {
        mainTextComponent.text = string.Empty;
        nameText.text = string.Empty;
        StartCoroutine(ShowDialogues());
    }

    void Update()
    {
        // Handle player input for choices
        if (choicesDisplayed && Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Check the current dialogue file and handle the choice accordingly
            if (currentDialogue == "Assets/7.txt")
            {
                HandleChoiceAfterSeven(1);
            }
            else if (currentDialogue == "Assets/10.txt")
            {
                HandleChoiceAfterTen(1);
            }
            else
            {
                HandleChoice(1);
            }
        }
        else if (choicesDisplayed && Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Check the current dialogue file and handle the choice accordingly
            if (currentDialogue == "Assets/7.txt")
            {
                HandleChoiceAfterSeven(2);
            }
            else if (currentDialogue == "Assets/10.txt")
            {
                HandleChoiceAfterTen(2);
            }
            else
            {
                HandleChoice(2);
            }
        }
        else if (choicesDisplayed && Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Check the current dialogue file and handle the choice accordingly
            if (currentDialogue == "Assets/10.txt")
            {
                HandleChoiceAfterTen(3);
            }
        }
    }

    IEnumerator ShowDialogues()
    {
        // Show the initial dialogues
        yield return StartCoroutine(ShowDialogue("Assets/1.txt"));
        yield return StartCoroutine(ShowDialogue("Assets/2.txt"));
        yield return StartCoroutine(ShowDialogue("Assets/3.txt"));

        // Display the initial set of choices
        DisplayChoices();
    }

    IEnumerator ShowDialogue(string filePath)
    {
        // Read dialogue lines from the file
        string[] dialogueLines = File.ReadAllLines(filePath);
        currentDialogue = filePath; // Update the current dialogue variable

        // Type each line on the screen
        foreach (string line in dialogueLines)
        {
            yield return TypeLine(line);
        }

        // Test for Names
        if (filePath == "Assets/1.txt") {
            nameText.text = "VANE";
        }
        if (filePath == "Assets/2.txt") {
            nameText.text = "DOCTOR";
        }
        if (filePath == "Assets/3.txt") {
            nameText.text = "";
        }
        

        // Check and show additional dialogues based on the current file
        if (filePath == "Assets/4.txt" || filePath == "Assets/5.txt")
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(ShowDialogue("Assets/6.txt"));
        }
        else if (filePath == "Assets/6.txt")
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(ShowDialogue("Assets/7.txt"));
        }
        else if (filePath == "Assets/7.txt")
        {
            yield return new WaitForSeconds(1f);
            // Display choices after showing "7.txt"
            DisplayChoicesAfterSeven();
        }
        else if (filePath == "Assets/8.txt" || filePath == "Assets/9.txt")
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(ShowDialogue("Assets/10.txt"));
        }
        else if (filePath == "Assets/10.txt")
        {
            yield return new WaitForSeconds(1f);
            // Display choices after showing "10.txt"
            DisplayChoicesAfterTen();
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator TypeLine(string line)
    {
        // Display each character of the line with a delay
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
        // Display initial set of choices
        mainTextComponent.text = "1. V: an accident?! what happened\n2. V: two months?!?";
        choicesDisplayed = true;

        nameText.text = "VANE";
    }

    void DisplayChoicesAfterSeven()
    {
        // Display choices after showing "7.txt"
        mainTextComponent.text = "1. V: ...\n2. V: Who are you?";
        choicesDisplayed = true;

        
    }

    void DisplayChoicesAfterTen()
    {
        // Display choices after showing "10.txt"
        mainTextComponent.text = "1. V: What do you know about the accident?\n2. V: How do I know youre not lying about who you are?\n3. V: How old am I?";
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

    void HandleChoiceAfterSeven(int choice)
    {
        // Reset the choicesDisplayed flag after handling the choice
        choicesDisplayed = false;

        switch (choice)
        {
            case 1:
                // Handle the choice for "V: ..."
                StartCoroutine(ShowDialogue("Assets/8.txt"));
                break;
            case 2:
                // Handle the choice for "V: Who are you?"
                StartCoroutine(ShowDialogue("Assets/9.txt"));
                break;
            default:
                break;
        }
    }

    void HandleChoiceAfterTen(int choice)
    {
        // Reset the choicesDisplayed flag after handling the choice
        choicesDisplayed = false;

        switch (choice)
        {
            case 1:
                // Handle the choice for "V: What do you know about the accident?"
                StartCoroutine(ShowDialogue("Assets/11.txt"));
                break;
            case 2:
                // Handle the choice for "V: How do I know youre not lying about who you are?"
                StartCoroutine(ShowDialogue("Assets/12.txt"));
                break;
            case 3:
                // Handle the choice for "V: How old am I?"
                StartCoroutine(ShowDialogue("Assets/13.txt"));
                break;
            default:
                break;
        }
    }
}
