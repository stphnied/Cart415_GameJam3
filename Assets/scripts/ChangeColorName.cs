using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeColorName : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI textName;
    public Color Vane; // Set the desired color when text is empty
    public Color Doctor; // Set the default color
    public Color Lance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(textName.text == "VANE") {
            // Change the image color when text is empty
            image.color = Vane;
        }
         if (textName.text == "LANCE")
        {
            // Change the image color when text is empty
            image.color = Lance;
        }
        if (textName.text == "DOCTOR"||textName.text == "NURSE") {
            image.color = Doctor;
        }
    }
}
