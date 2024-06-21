using Mediapipe.Unity;
using UnityEngine;

public class PoseInputController : MonoBehaviour
{
    [SerializeField] private PoseLandmarkListAnnotation listAnnotation;
    [SerializeField] private float deltaThreshold = 0.5f;

    public Vector2 GetInput()
    {
        var input = GetInputFromPose();
        return CalculateMovement(input.x, input.y); 
    }
    
    private Vector2 GetInputFromPose()
    {
        var lefthand = listAnnotation[15];
        var leftshoulder = listAnnotation[11];
        
        var righthand = listAnnotation[16];
        var rightshoulder = listAnnotation[12];

        float leftdelta = lefthand.transform.position.y - leftshoulder.transform.position.y;
        float rightdelta = righthand.transform.position.y - rightshoulder.transform.position.y;
        return new Vector2(leftdelta, rightdelta);
    }

    private Vector2 CalculateMovement(float leftdelta, float rightdelta)
    {
        var movingUp = leftdelta> 0 && rightdelta > 0;
        var movingDown = leftdelta < 0 && rightdelta < 0;
        var movingLeft = leftdelta < 0 && rightdelta > 0;
        var movingRight = leftdelta > 0 && rightdelta < 0;
        
        if(movingUp){
            return new Vector2(0, 1);
        }

        if(movingDown)
        {
            return new Vector2(0, -1);
        }

        if(movingLeft){
            return new Vector2(-1, 0);
        }

        if(movingRight){
            return new Vector2(1, 0);
        }
        return Vector2.zero;
    }
}
