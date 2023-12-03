using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Endialogue: MonoBehaviour {
    public TextMeshProUGUI textComponent;
    TMP_Text nameText;
    public string[] lines; //put the lines of the dialogue here
    public float textSpeed;
    public int locationindex; //keep track of where the dialogue is at 
    public GameObject FadeObj;
    public GameObject nextdialogue;
    public GameObject BFF;
    public GameObject Nurse;
    public GameObject oldMC;
    public GameObject NewMC;

    public GameObject oldCamera;
    public GameObject newCamera;
    GameObject NurseMouth;


    // Start is called before the first frame update
    void Start() {
        textComponent.text = string.Empty;
        nameText = GameObject.Find("Canvas/Name").GetComponent < TMP_Text > ();
        StartDialogue();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            if (textComponent.text == lines[locationindex]) {
                NextLine(); //display the next line
            } else {
                StopAllCoroutines();
                textComponent.text = lines[locationindex]; //just get the current line and fill it out

            }
        }

        ChangeName();
    }

    void ChangeName() {
        if (this.name == "DialogueBoxenditalics") {
            if (locationindex == 0) {
                FadeObj.SetActive(true);
                FadeObj.GetComponent < FadeOut > ().Fade();
                BFF.SetActive(false);
                nameText.text = "VANE";
            }

        } else if (this.name == "DialogueBoxend") {
            // BEGIN
            if (locationindex == 0) {
                oldCamera.SetActive(false);
                newCamera.SetActive(true);
                oldMC.SetActive(false);
                NewMC.SetActive(true);

            } else if (locationindex == 1) {
                FadeObj.SetActive(true);
                FadeObj.GetComponent < FadeOut > ().Fade();
                Nurse.SetActive(true);
                NurseMouth = GameObject.Find("Nurse/Head/Mouth_01");
                NurseMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
            }
            // NURSE
            else if (locationindex == 3 || locationindex == 4 || locationindex == 5 || locationindex == 7) {
                nameText.text = "NURSE";
                NurseMouth = GameObject.Find("Nurse/Head/Mouth_01");
                NurseMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(0);
            }
            // VANE
            else if (
                locationindex == 2 || locationindex == 6) {
                nameText.text = "VANE";
                NurseMouth = GameObject.Find("Nurse/Head/Mouth_01");
                NurseMouth.GetComponent<ChangeMouth>().SwitchTextureExternally(3);
            }
        }
        // ENDING
        else if (this.name == "DialogueBoxenditalicsend") {
            nameText.text = "VANE";
            if (locationindex == 1) {
            FadeObj.SetActive(true);
            FadeObj.GetComponent < FadeOut > ().FadeEnd();
            }

        }
    }

    void StartDialogue() {
        locationindex = 0; //start he dialogue at 0
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        //type each character 1by 1

        foreach(char c in lines[locationindex].ToCharArray()) {
            textComponent.text += c;
            yield
            return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {
        if (locationindex < lines.Length - 1) //move on to the other lines
        {
            locationindex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else //if nothing else to say close hte dialogue box
        {

            nextdialogue.SetActive(true);
            gameObject.SetActive(false);
        }
    }


}