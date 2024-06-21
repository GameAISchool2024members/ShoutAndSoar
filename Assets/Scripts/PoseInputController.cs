using System;
using Mediapipe.Unity;
using UnityEngine;

public class PoseInputController : MonoBehaviour
{
    [SerializeField] 
    private PoseLandmarkListAnnotation listAnnotation;
    // [SerializeField] 
    // private float deltaThreshold = 0.5f;
    [SerializeField, Tooltip("The maximum angle between hands and elbow. Used to smooth the plane movement")] 
    private float _maxAngle = 70;

    private Vector2 _input;


    private void Update()
    {
        var result = GetInputFromPose();
        _input = CalculateMovement(result.x, result.y);
    }

    public Vector2 GetInput()
    {
        return _input;
    }
    
    private Vector2 GetInputFromPose()
    {
        var lefthand = listAnnotation[15];
        var leftshoulder = listAnnotation[11];
        
        var righthand = listAnnotation[16];
        var rightshoulder = listAnnotation[12];

        // Calculate vectors from shoulders to hands
        var leftVector = lefthand.transform.position - leftshoulder.transform.position;
        var rightVector = righthand.transform.position - rightshoulder.transform.position;

        // Calculate the angles with the x-axis
        float leftAngle = Mathf.Clamp(-Mathf.Atan2(-leftVector.y, -leftVector.x) * Mathf.Rad2Deg, -_maxAngle, _maxAngle);
        float rightAngle = Mathf.Clamp(Mathf.Atan2(rightVector.y, rightVector.x) * Mathf.Rad2Deg, -_maxAngle, _maxAngle);
        
        return new Vector2(leftAngle, rightAngle);
    }

    private Vector2 CalculateMovement(float leftAngle, float rightAngle)
    {
        var leftNormalized = leftAngle / _maxAngle;
        var rightNormalized = rightAngle / _maxAngle;
        

        var movingUp = leftNormalized > 0 && rightNormalized > 0;
        var movingDown = leftNormalized < 0 && rightNormalized < 0;
        var movingLeft = leftNormalized < 0 && rightNormalized > 0;
        var movingRight = leftNormalized > 0 && rightNormalized < 0;
        
        if(movingUp || movingDown){
            return new Vector2(0, rightNormalized);
        }

        if(movingLeft || movingRight){
            return new Vector2(leftNormalized, 0);
        }

        return Vector2.zero;
    }
}
