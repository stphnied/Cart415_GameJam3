using System.Collections;
using UnityEngine;
using TMPro;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI mainTextComponent;
    public TextMeshProUGUI choicesTextComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    public string[] choices;
    public GameObject choicesPanel;

    private int selectedChoiceIndex = -1;
    private string originalFilePath;

    void Start()
    {
        mainTextComponent.text = string.Empty;
        choicesTextComponent.text = string.Empty;
        originalFilePath = "Assets/dialogue.txt";  // setting the original file path
        ReadDialogueFile(originalFilePath);
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (choicesPanel.activeSelf)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                // check if the corresponding number key is pressed
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    selectedChoiceIndex = i;
                    LogPlayerChoice();
                }
            }
        }
        else if (mainTextComponent.text == lines[index])
        {
            DisplayChoices();
        }
        else
        {
            StopAllCoroutines();
            mainTextComponent.text = lines[index];
        }
    }

    void ReadDialogueFile(string filePath)
    {
        string[] dialogueLines = File.ReadAllLines(filePath);

        // the first line of the file is the main dialogue
        lines = new string[] { dialogueLines[0] };
        choices = new string[dialogueLines.Length - 1];
        for (int i = 1; i < dialogueLines.Length; i++)
        {
            choices[i - 1] = dialogueLines[i];
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            mainTextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(2f);

        if (choices != null && choices.Length > 0)
        {
            DisplayChoices();
        }
        else
        {
            NextLine();
        }
    }

    void DisplayChoices()
    {
        choicesPanel.SetActive(true);
        choicesTextComponent.text = string.Empty;

        for (int i = 0; i < choices.Length; i++)
        {
            choicesTextComponent.text += $"\n{i + 1}. {choices[i]}";
        }

        // method is not called multiple times
        StopCoroutine("HideChoicesTextComponent");
        StartCoroutine(HideChoicesTextComponent());
    }

    void LogPlayerChoice()
    {
        if (selectedChoiceIndex != -1 && selectedChoiceIndex < choices.Length)
        {
            Debug.Log($"Player chose: {choices[selectedChoiceIndex]}");

    
            string newFilePath = string.Empty;

            switch (selectedChoiceIndex)
            {
                case 0:
                    newFilePath = "Assets/Good.txt";
                    break;
                case 1:
                    newFilePath = "Assets/Fine.txt";
                    break;
                case 2:
                    newFilePath = "Assets/Bad.txt";
                    break;
                // add more cases if you have additional choices
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(newFilePath))
            {
                ReadDialogueFile(newFilePath);
            }

            choicesPanel.SetActive(false);
            StartCoroutine(HideChoicesTextComponent());
            mainTextComponent.gameObject.SetActive(true);
        }
    }

    IEnumerator HideChoicesTextComponent()
    {
        yield return new WaitForSeconds(0.1f);
        choicesTextComponent.gameObject.SetActive(false);
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
            gameObject.SetActive(false);
        }
    }

    void ReturnToOriginalFile()
    {
        ReadDialogueFile(originalFilePath);
        StartCoroutine(TypeLine());
    }
}
