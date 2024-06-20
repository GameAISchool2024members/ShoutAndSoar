using UnityEngine;

public class VoiceDetection : MonoBehaviour
{
    public MicrophoneInput micInput;
    public int counter = 0;
    public GameObject plane;
    public float moveSpeed = 10.0f; // Speed at which the plane moves

    void Start()
    {
        // Ensure MicrophoneInput script is attached to an object in the scene
        micInput = FindObjectOfType<MicrophoneInput>();
    }

    void Update()
    {
        counter++;
        if (counter >= 10)
        {
            string roundedLoudnessStr = micInput.loudness.ToString("F2");
            float roundedLoudness = float.Parse(roundedLoudnessStr);
            counter = 0;
            Debug.Log("Loudness: " + roundedLoudness);
            if (roundedLoudness == 0)
            {
                // Move the plane down (negative y direction)
                MovePlane(Vector3.down);
            }
            else
            {
                // Move the plane up (positive y direction)
                MovePlane(Vector3.up);
            }
        }
    }

    private void MovePlane(Vector3 direction)
    {
        // Move the plane in the specified direction at the specified speed
        plane.transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}