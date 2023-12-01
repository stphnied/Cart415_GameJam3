using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Endialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    TMP_Text nameText;
    public string[] lines; //put the lines of the dialogue here
    public float textSpeed;  
    public int locationindex; //keep track of where the dialogue is at 

 
    public GameObject nextdialogue;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        nameText = GameObject.Find("Canvas/Name").GetComponent<TMP_Text>();
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

    ChangeName();
    }

    void ChangeName() {
        if(this.name == "DialogueBoxenditalics") {
            nameText.text = "VANE";
        }
        else if(this.name == "DialogueBoxend") {
            if(locationindex==0||locationindex==2||locationindex==3||locationindex==4||locationindex==6) {nameText.text = "NURSE";}
            else if(locationindex==1||locationindex==5){nameText.text = "LANCE";}
        }
        else if(this.name =="DialogueBoxenditalicsend") {
            nameText.text = "VANE";
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
