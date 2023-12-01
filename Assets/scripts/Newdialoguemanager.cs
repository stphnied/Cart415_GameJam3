using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Newdialoguemanager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines; //put the lines of the dialogue here
    public float textSpeed;  
    public int locationindex; //keep track of where the dialogue is at 

    public GameObject button_1;
    public GameObject button_2;
    public GameObject button_3;
    public GameObject enditalics;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[locationindex])
            {
                NextLine(); //display the next line
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[locationindex]; //just get the current line and fill it out

            }
        }

       
    }


    void StartDialogue()
    {
    locationindex = 0; //start he dialogue at 0
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //type each character 1by 1

        foreach (char c in lines[locationindex].ToCharArray()) 
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    void NextLine()
    {
        if (locationindex<lines.Length-1) //move on to the other lines
        { locationindex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else //if nothing else to say close hte dialogue box
        {
            Debug.Log(ChoiceManager.choiceTracker);
            if (ChoiceManager.choiceTracker < 13) // if its not done with the 13 dialogue boxes it continues 
            { 
                button_1.SetActive(true);
                button_2.SetActive(true);
                if (ChoiceManager.choiceTracker == 3 || ChoiceManager.choiceTracker == 4 || ChoiceManager.choiceTracker == 8 || ChoiceManager.choiceTracker == 9) // for the times that there are 3 options
                {
                    button_3.SetActive(true);
                }
            }
           
            else // goes into the end dialogue
            {
                enditalics.SetActive(true);
                gameObject.SetActive(false);

            }
        }
    }


}
