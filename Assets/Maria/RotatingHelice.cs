using UnityEngine;

public class RotateHelix : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed at which the rotation speed increases

    void Update()
    {
        // Calculate the new rotation for the X axis over time
        float newRotationX = rotationSpeed * Time.deltaTime;
        
        // Apply the rotation to the object
        transform.Rotate(newRotationX, 0, 0);
    }
}