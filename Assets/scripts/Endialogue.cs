using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Endialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines; //put the lines of the dialogue here
    public float textSpeed;  
    public int locationindex; //keep track of where the dialogue is at 

 
    public GameObject nextdialogue;


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
        
            nextdialogue.SetActive(true);
            gameObject.SetActive(false);
        }
    }


}
