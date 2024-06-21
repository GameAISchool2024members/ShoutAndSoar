
using Unity.VisualScripting;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField]
    float _seconds = 2f;
    void Awake()
    {
        Destroy(this.gameObject, _seconds);
    }

}