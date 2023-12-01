using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices : MonoBehaviour
{
    public static int count = 0;
    // This is hard coded to got wheer it needs to. if you need the numbers look at the dialogue box and do -1 
    // The button have the same script but run the different choices
    public void makeChoice1()
    {
        if (ChoiceManager.choiceTracker == 0)
        {
            ChoiceManager.choiceTracker = 1;
        }
        else if (ChoiceManager.choiceTracker == 1 || ChoiceManager.choiceTracker == 2)
        {
            ChoiceManager.choiceTracker = 3;
        }
        else if (ChoiceManager.choiceTracker == 3 || ChoiceManager.choiceTracker == 4)
        {
            ChoiceManager.choiceTracker = 5;

        }
        
        else if (ChoiceManager.choiceTracker == 5 || ChoiceManager.choiceTracker == 6 || ChoiceManager.choiceTracker == 7)
        {
            ChoiceManager.choiceTracker = 8;
        }
        else if (ChoiceManager.choiceTracker == 8 || ChoiceManager.choiceTracker == 9)
        {
            ChoiceManager.choiceTracker = 10;
        }
        else if (ChoiceManager.choiceTracker == 10 || ChoiceManager.choiceTracker == 11 || ChoiceManager.choiceTracker == 12)
        {
            ChoiceManager.choiceTracker = 13;
        }


    }
    public void makeChoice2()
    {
        if (ChoiceManager.choiceTracker == 0)
        {
            ChoiceManager.choiceTracker = 2;
        }
        else if (ChoiceManager.choiceTracker == 1 || ChoiceManager.choiceTracker == 2 )
        {
            ChoiceManager.choiceTracker = 4;
        }
        else if ( ChoiceManager.choiceTracker == 3 || ChoiceManager.choiceTracker == 4)
        {
            ChoiceManager.choiceTracker = 6;
        }
        else if (ChoiceManager.choiceTracker == 5)
        {
            ChoiceManager.choiceTracker = 9;
        }
        else if (ChoiceManager.choiceTracker == 6 || ChoiceManager.choiceTracker == 7)
        {
            ChoiceManager.choiceTracker = 9;

        }
        else if (ChoiceManager.choiceTracker == 8 || ChoiceManager.choiceTracker == 9)
        {
            ChoiceManager.choiceTracker = 11;
        }
        else if (ChoiceManager.choiceTracker == 10 || ChoiceManager.choiceTracker == 11 || ChoiceManager.choiceTracker == 12)
        {
            ChoiceManager.choiceTracker = 14;
        }
    


    }
    public void makeChoice3()
    {
        if (ChoiceManager.choiceTracker == 3 || ChoiceManager.choiceTracker == 4)
        {
            ChoiceManager.choiceTracker = 7;
        }
        else if (ChoiceManager.choiceTracker == 5)
        {
            ChoiceManager.choiceTracker = 9;
        }
        else if (ChoiceManager.choiceTracker == 8 || ChoiceManager.choiceTracker == 9)
        {
            ChoiceManager.choiceTracker = 12;
        }
    }
}
