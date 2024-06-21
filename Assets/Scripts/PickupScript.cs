using System;
using UnityEngine;
using UnityEngine.Events;

public class PickupScript : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Vector3> _onPickup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _onPickup.Invoke(transform.position);
            Destroy(gameObject);
        }
    }


    private void Awake()
    {
        // Destroy itself after 10 seconds
        Destroy(gameObject, 20f);
    }
}