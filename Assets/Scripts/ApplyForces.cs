using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForces : MonoBehaviour
{
    //Create a reference to the Rigidbody
    private Rigidbody rb;
    public float forceValue = 10f;
    public float torqueValue = 10f;
    public float puntValue = 10f;
    void Start()
    {
        //Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        //AddForce to Rigidbody
        rb.AddRelativeForce(0f, puntValue, forceValue, ForceMode.Impulse);

        //AddTorque to Rigidbody
        rb.AddRelativeTorque(transform.right * torqueValue, ForceMode.Impulse);
    }

    void Update()
    {
        
    }
}
