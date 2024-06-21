using System.Collections;
using System.Collections.Generic;
using Mediapipe.Unity;
using UnityEngine;
using UnityEngine.Rendering;

public class GetArmPosition : MonoBehaviour
{

    [SerializeField] private PoseLandmarkListAnnotation listAnnotation;
    [SerializeField] private float deltaThreshold = 0.5f;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float rotateSpeed = 10.0f;
    [SerializeField] private GameObject plane;
    private float currentRotation;

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

        currentRotation = Mathf.Clamp(currentRotation + (rotateSpeed * Time.deltaTime), -15.0f, 15.0f);
        

        if(leftdelta> 0 && rightdelta > 0){
            //plane.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y + 0.1f, plane.transform.position.z); 
            plane.transform.Translate(0, speed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, currentRotation, 0);
        }
        if(leftdelta < 0 && rightdelta < 0)
        {
            //plane.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y - 0.1f, plane.transform.position.z);
            plane.transform.Translate(0, -speed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, -currentRotation, 0);
        }
        if(leftdelta < 0 && rightdelta > 0){
            //plane.transform.position = new Vector3(plane.transform.position.x - 0.1f, plane.transform.position.y, plane.transform.position.z);
            plane.transform.Translate(-speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(-currentRotation, 0, 0);
        }
        if(leftdelta > 0 && rightdelta < 0){
            //plane.transform.position = new Vector3(plane.transform.position.x + 0.1f, plane.transform.position.y, plane.transform.position.z);           
            plane.transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
            
        }
    }
}
