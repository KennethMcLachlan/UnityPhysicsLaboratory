using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMailPackage : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void Init(Vector3 velocity)
    {
        //Apply force to the gameObject
        _rb.AddForce(velocity, ForceMode.Impulse);
    }
}
