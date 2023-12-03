using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public float fadeDuration; // Duration of the fade in seconds
    private Image image;
    private Color originalColor;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Invoke("Fade",2f);
    }

    public void Fade() {
         if (timer < fadeDuration)
        {
            // Calculate the alpha value based on the elapsed time
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

            // Apply the new color with faded alpha
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Update the timer
            timer += Time.deltaTime;
        }
    }    

    public void FadeEnd() {
        if (timer < fadeDuration)
{
        // Calculate the alpha value based on the elapsed time (reversed fade)
        float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);

        // Apply the new color with faded alpha
        image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

        // Update the timer
        timer += Time.deltaTime;
    }
    }   
}

