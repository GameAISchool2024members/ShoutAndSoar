using System.Collections;
using System.Collections.Generic;
using Mediapipe.Unity;
using UnityEngine;

public class GetArmPosition : MonoBehaviour
{

    [SerializeField] private PoseLandmarkListAnnotation listAnnotation;
    [SerializeField] private float DeltaThreshold = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var lefthand = listAnnotation[16];
        var righthand = listAnnotation[15];
        var rightshoulder = listAnnotation[11];
        var leftshoulder = listAnnotation[12];

        Vector3 leftdelta = lefthand.transform.position - leftshoulder.transform.position;
        Vector3 rightdelta = righthand.transform.position - rightshoulder.transform.position;

        Debug.Log(rightdelta + " " + leftdelta);
    }
}
