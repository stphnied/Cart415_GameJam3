using UnityEngine;

public class DisableMouseClick : MonoBehaviour
{
private float delayTime = 3f;  // Adjust this value to set the delay time in seconds
    private bool allowClick = false;

    void Start()
    {
        // Invoke the method to allow mouse clicks after the specified delay time
        Invoke("AllowMouseClick", delayTime);
    }

    void Update()
    {
        // Check if mouse clicks are allowed
        if (allowClick)
        {
            // Your normal update code here

            // Example: Check for mouse clicks
            if (Input.GetMouseButtonDown(0))
            {
                // Your click handling code here
                Debug.Log("Mouse Clicked!");
            }
        }
    }

    void AllowMouseClick()
    {
        // Set the flag to allow mouse clicks
        allowClick = true;
    }
}
