using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDOwn : MonoBehaviour
{
public float slideSpeed = 2.0f; // Speed at which the GameObject slides down
    public float targetY = -200.0f; // Target Y position for sliding

    private bool isSliding = false;

    void Update()
    {
        // Check if the GameObject is not already sliding
        if (!isSliding)
        {
            // Start sliding down
            StartSlideDown();
        }
    }

    void StartSlideDown()
    {
        // Set the flag to indicate that the GameObject is sliding
        isSliding = true;

        // Calculate the target anchored position
        Vector2 targetAnchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, targetY);

        // Use Vector2.Lerp to smoothly interpolate between current anchored position and target anchored position
        StartCoroutine(SlideCoroutine(targetAnchoredPosition));
    }

    // Coroutine to perform the sliding animation
    IEnumerator SlideCoroutine(Vector2 targetAnchoredPosition)
    {
        float elapsedTime = 0f;

        // Use while loop for the interpolation
        while (elapsedTime < 1f)
        {
            GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(GetComponent<RectTransform>().anchoredPosition, targetAnchoredPosition, elapsedTime * slideSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the GameObject reaches the exact target anchored position
        GetComponent<RectTransform>().anchoredPosition = targetAnchoredPosition;

        // Reset the sliding flag for future use
        isSliding = false;
    }
}
