using UnityEngine;
using UnityEngine.Audio;

public class MicrophoneInput : MonoBehaviour
{
    public float sensitivity = 100f; // Adjust this to control sensitivity of voice detection
    public float loudness = 0f;

    void Start()
    {
        // Check if microphone is available
        if (Microphone.devices.Length == 0)
        {
            Debug.LogWarning("No microphone detected!");
            return;
        }

        // Start recording from the first detected microphone
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { } // Wait until recording starts
        audioSource.Play();
    }

    void Update()
    {
        // Calculate RMS (Root Mean Square) to determine loudness
        AudioSource audioSource = GetComponent<AudioSource>();
        float[] samples = new float[1024];
        audioSource.GetOutputData(samples, 0);
        float sum = 0;
        foreach (float sample in samples)
        {
            sum += sample * sample;
        }
        loudness = sensitivity * Mathf.Sqrt(sum / samples.Length);
    }
}