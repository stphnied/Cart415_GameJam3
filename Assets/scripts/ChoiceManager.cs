using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceManager : MonoBehaviour
{

    public static int choiceTracker = 0 ;
    /*
     * 1- V: an accident?! what happened 
     * 2- V: two months?!?
     * 
     * 3- V: �
     * 4- V: Who are you?
     * 
     * 5- V: What do you know about the accident?
     * 6- V: How do I know you�re not lying about who you are?
     * 7- V: How old am I?
     * 
     * 8- V: Who is Sara?
     * 9- V: What date is it?
     * 
     * 10- V: Did they never come visit?
     * 11- V: Any family nearby?
     * 12- V: Am I close with them?
     * 
     * 13-V: Where do I live?
     * 12-V: Are you the one who decorated the room?
     * 
     * 
     */
    public GameObject button_1;
    public GameObject button_2;
    public GameObject button_3;
    public GameObject DialogueBoxp1;
    public GameObject DialogueBoxp2;
    public GameObject DialogueBoxp3;
    public GameObject DialogueBoxp4;
    public GameObject DialogueBoxp5;
    public GameObject DialogueBoxp6;
    public GameObject DialogueBoxp7;
    public GameObject DialogueBoxp8;
    public GameObject DialogueBoxp9;
    public GameObject DialogueBoxp10;
    public GameObject DialogueBoxp11;
    public GameObject DialogueBoxp12;
    public GameObject DialogueBoxp13;
    public GameObject DialogueBoxp14;
    public GameObject DialogueBoxp15;

    public void displayManager()
    {
        //baiscally for each one, display the right text box and hide the others, it also preps the text for the next options
        if (choiceTracker == 1)
        {
            DialogueBoxp2.SetActive(true);
            DialogueBoxp1.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "Who are you?";
        } else if (choiceTracker == 2)
        {
            DialogueBoxp3.SetActive(true);
            DialogueBoxp2.SetActive(false);
            DialogueBoxp1.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "Who are you?";
        } 

        else if (choiceTracker == 3)
        {
            DialogueBoxp4.SetActive(true);
            DialogueBoxp2.SetActive(false);
            DialogueBoxp3.SetActive(false);
            DialogueBoxp1.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "What do you know about the accident?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "How do I know you're not lying about who you are?";
            button_3.SetActive(true);
            GameObject.Find("choicethree").GetComponentInChildren<TMP_Text>().text = "How old am I?";
            button_3.SetActive(false);
            
        } else if (choiceTracker == 4)
        {
            DialogueBoxp5.SetActive(true);
            DialogueBoxp2.SetActive(false);
            DialogueBoxp3.SetActive(false);
            DialogueBoxp1.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "What do you know about the accident?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "How do I know you're not lying about who you are?";
            button_3.SetActive(true);
            GameObject.Find("choicethree").GetComponentInChildren<TMP_Text>().text = "How old am I?";
  
         
        } 
        
        else if (choiceTracker == 5)
        {
            DialogueBoxp6.SetActive(true);
            DialogueBoxp4.SetActive(false);
            DialogueBoxp5.SetActive(false);
            DialogueBoxp3.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "Who is Sara?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "What date is it?";
        } else if (choiceTracker == 6)
        {
            DialogueBoxp7.SetActive(true);
            DialogueBoxp4.SetActive(false);
            DialogueBoxp5.SetActive(false);
            DialogueBoxp3.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "Who is Sara?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "What date is it?";
        }  else if (choiceTracker == 7)
        {
            DialogueBoxp8.SetActive(true);
            DialogueBoxp7.SetActive(false);
            DialogueBoxp4.SetActive(false);
            DialogueBoxp5.SetActive(false);
            DialogueBoxp6.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "Who is Sara?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "What date is it?";
        }
      
        else if (choiceTracker == 8)
        {
            DialogueBoxp9.SetActive(true);
            DialogueBoxp5.SetActive(false);
            DialogueBoxp6.SetActive(false);
            DialogueBoxp8.SetActive(false);
            DialogueBoxp7.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "Did they never come visit?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "Any family nearby?";
            button_3.SetActive(true);
            GameObject.Find("choicethree").GetComponentInChildren<TMP_Text>().text = "Am I close with them?";
 
          
        }   else if (choiceTracker == 9)
        {
            DialogueBoxp10.SetActive(true);
            DialogueBoxp5.SetActive(false);
            DialogueBoxp6.SetActive(false);
            DialogueBoxp7.SetActive(false);
            DialogueBoxp8.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "Did they never come visit?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "Any family nearby?";
            button_3.SetActive(true);
            GameObject.Find("choicethree").GetComponentInChildren<TMP_Text>().text = "Am I close with them?";
    
        } 
        

        else if (choiceTracker == 10)
        {
            DialogueBoxp11.SetActive(true);
            DialogueBoxp9.SetActive(false);
            DialogueBoxp10.SetActive(false);
            DialogueBoxp8.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "Where do I live?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "Are you the one who decorated the room?";
           
        } else if (choiceTracker == 11)
        {
            DialogueBoxp12.SetActive(true);
            DialogueBoxp9.SetActive(false);
            DialogueBoxp10.SetActive(false);
            DialogueBoxp11.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "Where do I live?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "Are you the one who decorated the room?";
     
        } else if (choiceTracker == 12)
        {
            DialogueBoxp13.SetActive(true);
            DialogueBoxp9.SetActive(false);
            DialogueBoxp10.SetActive(false);
            DialogueBoxp11.SetActive(false);
            GameObject.Find("choiceone").GetComponentInChildren<TMP_Text>().text = "Where do I live?";
            GameObject.Find("choicetwo").GetComponentInChildren<TMP_Text>().text = "Are you the one who decorated the room?";

        } 
        
        else if (choiceTracker == 13)
        {
            DialogueBoxp14.SetActive(true);
            DialogueBoxp11.SetActive(false);
            DialogueBoxp12.SetActive(false);
            DialogueBoxp13.SetActive(false);
         
        } else if (choiceTracker == 14)
        {
            DialogueBoxp15.SetActive(true);
            DialogueBoxp11.SetActive(false);
            DialogueBoxp12.SetActive(false);
            DialogueBoxp13.SetActive(false);
       
        }

        button_1.SetActive(false);
        button_2.SetActive(false);
        button_3.SetActive(false);
    }
}
