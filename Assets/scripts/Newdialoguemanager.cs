using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Newdialoguemanager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    TMP_Text nameText;
    public string[] lines; //put the lines of the dialogue here
    public float textSpeed;  
    public int locationindex; //keep track of where the dialogue is at 
    

    public GameObject button_1;
    public GameObject button_2;
    public GameObject button_3;
    public GameObject enditalics;

    public GameObject Bestie;
    public GameObject Doctor;
    GameObject DoctorMouth;
    GameObject BestieMouth;
    public GameObject FadeDoctor;
    public GameObject FadeObj;
    private bool stop= false;
    private bool gameStart = false;

    GameObject Sound;

    // Start is called before the first frame update
    void Start()
    {
        nameText = GameObject.Find("Canvas/Name").GetComponent<TMP_Text>();
        DoctorMouth = GameObject.Find("Doctor/Head/Mouth_01");
        Sound = GameObject.Find("Sound");
        nameText.text = "";
        textComponent.text = string.Empty;

        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&gameStart)
        {
            if (textComponent.text == lines[locationindex])
            {
                NextLine(); //display the next line
                Sound.GetComponent<PlaySounds>().TypeWritter();
                Sound.GetComponent<PlaySounds>().ClickSound();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[locationindex]; //just get the current line and fill it out
                Sound.GetComponent<PlaySounds>().StopSound();
            }
        }

    ChangeName();
    }

    void ChangeName() {
        // Dialogue 1
        if (this.name == "DialogueBoxp1") {
            FadeObj.GetComponent<FadeOut>().Fade();
            if (FadeObj.GetComponent<FadeOut>().timer >=2.5f) {
                gameStart = true;
                FadeObj.SetActive(false);
            }
            if(locationindex==0) {nameText.text = "VANE";}

            else {
                nameText.text = "DOCTOR";
                DoctorMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(3);
                }
        }

        // Dialogue 2||3
        else if (this.name == "DialogueBoxp2"||this.name == "DialogueBoxp3") {
            gameStart = true;
            if(locationindex==2) {
                nameText.text ="DOCTOR";
                DoctorMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(4);
                }
            else if(locationindex==3) {
                nameText.text = "VANE";
                }
            else if(locationindex==6) {
                nameText.text ="";
                DoctorMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(4);
            }

            // Lance appears
            else if (locationindex==7) {
                nameText.text = "DOCTOR";
                FadeObj.SetActive(true);
                FadeObj.GetComponent<FadeOut>().Fade();
                Bestie.SetActive(true);
                BestieMouth = GameObject.Find("BFF/Head/Mouth_01");
                DoctorMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(4);
            }
            else if(locationindex==8) {
                nameText.text = "DOCTOR";
                Doctor.GetComponent<Turning>().LanceArrived();
                DoctorMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
            }
            else if(locationindex==9) {
                nameText.text = "LANCE";
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(4);
                DoctorMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(4);
                if(!stop) {
                    Bestie.GetComponent<Animator>().SetTrigger("Test");
                    stop = true;
                }
            }

            // Doc leaves
            else if(locationindex==11) {
                DoctorMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(3);
                FadeDoctor.SetActive(true);
                FadeDoctor.GetComponent<FadeOut>().Fade();
                Doctor.SetActive(false);

                nameText.text = "LANCE";
                Bestie.GetComponent<Turning>().LancetoMC();
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
                }
            else {
                nameText.text = "DOCTOR";
                DoctorMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
            }
        }
        // Dialogue 4||5
        else if(this.name == "DialogueBoxp4"||this.name == "DialogueBoxp5") {
            gameStart = true;
            BestieMouth = GameObject.Find("BFF/Head/Mouth_01");
            nameText.text = "LANCE";
            if(locationindex==0) {
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(2);
            }
            else if(locationindex==3) {
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(3);
            }
            else {
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
            }
        }
        // Dialogue 6||7||8
        else if (this.name == "DialogueBoxp6"||this.name == "DialogueBoxp7"||this.name == "DialogueBoxp8") {
            gameStart = true;
            BestieMouth = GameObject.Find("BFF/Head/Mouth_01");
            nameText.text = "LANCE";

            if(locationindex==0) {
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
            } else {BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(3);}

        }

        // Dialogue 9 --> Sarah's question
        else if(this.name == "DialogueBoxp9") {
            gameStart = true;
            BestieMouth = GameObject.Find("BFF/Head/Mouth_01");
            nameText.text = "LANCE";

            if(locationindex==0||locationindex==1||locationindex==2) 
            {
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(4);
            }
            else if (locationindex==6) {
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(3);
            }
            else {
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
            }
        }

        else if(this.name == "DialogueBoxp10"||this.name == "DialogueBoxp11"||this.name == "DialogueBoxp12"||this.name == "DialogueBoxp13") {
            gameStart = true;
            BestieMouth = GameObject.Find("BFF/Head/Mouth_01");
            nameText.text = "LANCE";
            BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);

            if(locationindex==1||locationindex==2) {
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(3);
            }
        }

        // Dialogue 14
        else if(this.name == "DialogueBoxp14") {
            gameStart = true;
            if(locationindex==2) {nameText.text = "VANE";}
            else {
                nameText.text = "LANCE";
                BestieMouth = GameObject.Find("BFF/Head/Mouth_01");
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
                }
        }
        // Dialogue 15
        else if(this.name == "DialogueBoxp15") {
            gameStart = true;
            if(locationindex==3) {nameText.text = "VANE";}
            else {
                nameText.text = "LANCE";
                BestieMouth = GameObject.Find("BFF/Head/Mouth_01");
                BestieMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
            }
        }
        
        // The rest
        else {nameText.text = "LANCE";gameStart = true;}
    }

    void StartDialogue()
    {
        Sound.GetComponent<PlaySounds>().TypeWritter();  
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

        else //if nothing else to say close the dialogue box
        {
            Sound.GetComponent<PlaySounds>().StopSound();
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
