
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{   
    float targetRotationY;
    public float rotationSpeed; // Adjustable rotation speed

    void Update()
    {
       
    }

    public void LanceArrived() {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("YourAnimationName"))
        {
            // Add a value to the current Y rotation
            float newRotationY = transform.eulerAngles.y + rotationSpeed * Time.deltaTime;

            // Apply the new rotation to the GameObject
            // transform.eulerAngles = new Vector3(transform.eulerAngles.x, newRotationY, transform.eulerAngles.z);
        }
        targetRotationY = 150f;
        // Quaternion targetRotation = Quaternion.Euler(0f, targetRotationY, 0f);

        // Apply the rotation to the GameObject
        // transform.rotation = targetRotation;
        RotateTowardsTargetRotation();
    }


    public void LancetoDoc() {
        targetRotationY = 25f;
        // RotateTowardsTargetRotation();
    }

    public void LancetoMC() {
        targetRotationY = 55f;
        
        RotateTowardsTargetRotation();
    }

    void RotateTowardsTargetRotation()
    {
        // Calculate the difference between the current rotation and the target rotation
        float angleDifference = targetRotationY - transform.eulerAngles.y;

        // Normalize the angle to be within the range [-180, 180]
        angleDifference = Mathf.Repeat(angleDifference + 180f, 360f) - 180f;

        // Calculate the rotation step based on the rotation speed
        float rotationStep = rotationSpeed * Time.deltaTime;

        // If the angle difference is greater than the rotation step, rotate towards the target rotation
        if (Mathf.Abs(angleDifference) > rotationStep)
        {
            // Calculate the new Y rotation
            float newRotationY = transform.eulerAngles.y + Mathf.Sign(angleDifference) * rotationStep;

            // Apply the new rotation to the GameObject
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newRotationY, transform.eulerAngles.z);
        }
    }
}
