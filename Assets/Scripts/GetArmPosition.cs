using System.Collections;
using System.Collections.Generic;
using Mediapipe.Unity;
using UnityEngine;

public class GetArmPosition : MonoBehaviour
{

    [SerializeField] private PoseLandmarkListAnnotation listAnnotation;
    [SerializeField] private float deltaThreshold = 0.5f;
    [SerializeField] private GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var lefthand = listAnnotation[15];
        var leftshoulder = listAnnotation[11];
        
        var righthand = listAnnotation[16];
        var rightshoulder = listAnnotation[12];

        float leftdelta = lefthand.transform.position.y - leftshoulder.transform.position.y;
        float rightdelta = righthand.transform.position.y - rightshoulder.transform.position.y;

        

        if(leftdelta> 0 && rightdelta > 0){
            plane.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y + 0.1f, plane.transform.position.z); 
        }
        if(leftdelta < 0 && rightdelta < 0)
        {
            plane.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y - 0.1f, plane.transform.position.z);
        }
        if(leftdelta < 0 && rightdelta > 0){
            plane.transform.position = new Vector3(plane.transform.position.x - 0.1f, plane.transform.position.y, plane.transform.position.z);
        }
        if(leftdelta > 0 && rightdelta < 0){
            plane.transform.position = new Vector3(plane.transform.position.x + 0.1f, plane.transform.position.y, plane.transform.position.z);           
        }
    }
}
