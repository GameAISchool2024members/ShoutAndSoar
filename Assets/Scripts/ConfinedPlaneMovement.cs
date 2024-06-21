using System;
using UnityEngine;

public class ConfinedPlaneMovement : MonoBehaviour
{
    [SerializeField]
    private PoseInputController _poseInputController;
    [SerializeField]
    private GameObject _plane;
    [Header("Plane Speed")]
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField] private float _rotateSpeed = 1.0f; 
    private Camera _mainCamera;
    
    [Header("Plane Constraints")]
    [SerializeField]
    private float MaxX = 1;
    [SerializeField]
    private float MaxY = 1;
     

    private float CurRotationX = 0.0f; 
    private float CurRotationZ = 0.0f; 


    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var input = _poseInputController.GetInput();
        var movement = input * (_speed * Time.deltaTime);

        _plane.transform.Translate(movement.x, movement.y, 0);
        
        // Confine plane within bounds
        var position = _plane.transform.position;
        position.x = Mathf.Clamp(position.x, -MaxX / 2, MaxX / 2);
        position.y = Mathf.Clamp(position.y, -MaxY / 2, MaxY / 2);
        _plane.transform.position = position;
    
        // Tilt or rotate plane based on movement direction
        CurRotationX += -movement.y * _rotateSpeed;
        CurRotationZ += -movement.x * _rotateSpeed;

        // Limit the rotation
        CurRotationX = Mathf.Clamp(CurRotationX, -30.0f, 30.0f);
        CurRotationZ = Mathf.Clamp(CurRotationZ, -15.0f, 15.0f);

        // _plane.transform.rotation = Quaternion.Euler(CurRotationX, 0, CurRotationZ);
    }

    private void OnDrawGizmosSelected()
    {
        if (_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }

        Gizmos.color = Color.red;

        Vector3 planePosition = _plane.transform.position;
        Vector3 minBound = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, planePosition.z - _mainCamera.transform.position.z));
        Vector3 maxBound = _mainCamera.ViewportToWorldPoint(new Vector3(1, 1, planePosition.z - _mainCamera.transform.position.z));

        Vector3 center = (minBound + maxBound) / 2;
        Vector3 size = new Vector3(MaxX, MaxY, 0);

        Gizmos.DrawWireCube(center, size);
    }
}
