using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 2.0f; // Adjust this value to control the camera movement speed

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        // Move the camera based on mouse input
        Vector3 newPosition = transform.position;
        newPosition.x += mouseX * sensitivity * Time.deltaTime;
        transform.position = newPosition;
    }
}
