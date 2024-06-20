using System.Collections;
using System.Collections.Generic;
using Mediapipe.Unity;
using UnityEngine;

public class PoseDetector : MonoBehaviour
{
    public PoseLandmarkListAnnotation poseDetectionAnnotationController;
    
    // Update is called once per frame
    void Update()
    {
        if (poseDetectionAnnotationController)
        {
            var t = poseDetectionAnnotationController[0];
            Debug.DrawLine(Vector3.zero, t.transform.position, Color.red, 0.1f);
            var leftHand = poseDetectionAnnotationController[16];
            var rightHand = poseDetectionAnnotationController[15];
            Debug.DrawLine(Vector3.zero, rightHand.transform.position, Color.green, 0.1f);
            Debug.DrawLine(Vector3.zero, leftHand.transform.position, Color.blue, 0.1f);
            
        }
    }
}
