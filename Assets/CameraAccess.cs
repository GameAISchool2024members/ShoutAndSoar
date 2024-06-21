using System.Collections;
using UnityEngine;

public class CameraAccess : MonoBehaviour
{
    IEnumerator Start()
    {
        FindWebCams();

        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.Log("webcam found");
        }
        else
        {
            Debug.Log("webcam not found");
        }

        // FindMicrophones();
        //
        // yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        // if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        // {
        //     Debug.Log("Microphone found");
        // }
        // else
        // {
        //     Debug.Log("Microphone not found");
        // }
    }

    void FindWebCams()
    {
        foreach (var device in WebCamTexture.devices)
        {
            Debug.Log("Name: " + device.name);
        }
    }

    // void FindMicrophones()
    // {
    //     foreach (var device in Microphone.devices)
    //     {
    //         Debug.Log("Name: " + device);
    //     }
    // }
}
