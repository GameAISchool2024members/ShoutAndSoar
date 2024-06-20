using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    // Speed at which the object moves along the z-axis
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance to move based on speed and time since last frame
        float distance = speed * Time.deltaTime;

        // Move the object along the z-axis
        transform.Translate(0, 0, distance);
        
    }
}