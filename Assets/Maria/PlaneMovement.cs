using UnityEngine;
using UnityEngine.Serialization;

public class PlaneMovement : MonoBehaviour
{
    // Speed at which the object moves along the z-axis
    public float speed = 1.0f;

    [SerializeField]
    AnimationCurve _speedRampUpCurve;
    [SerializeField] 
    private float _timeToMaxSpeed;
    [SerializeField]
    private float _speedMultiplier = 20f;
    private float _timeElapsed = 0f;

    private float _speedRamp;

    public float SpeedRamp => _speedRamp;
    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
    
        // Ramp up the speed over time
        _speedRamp = _speedRampUpCurve.Evaluate(_timeElapsed / _timeToMaxSpeed);
        // Calculate the distance to move based on speed and time since last frame
        float distance = speed * Time.deltaTime;
        
        distance += distance * _speedRamp * _speedMultiplier; 
        
        

        // Move the object along the z-axis
        transform.Translate(0, 0, distance);
    }
}