using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMailPackage : MonoBehaviour
{
    //Reference to the rigidbody
    [SerializeField] private Rigidbody _rb;

    //Create a method that will pass in velocity/power value from launcher

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
