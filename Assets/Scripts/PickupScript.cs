using System;
using UnityEngine;
using UnityEngine.Events;

public class PickupScript : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onPickup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _onPickup.Invoke();
            Destroy(gameObject);
        }
    }


    private void Awake()
    {
        // Destroy itself after 10 seconds
        Destroy(gameObject, 10f);
    }
}