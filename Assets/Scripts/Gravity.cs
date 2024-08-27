using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _defaultGravityValue = -9.81f;
    void Start()
    {
        Physics.gravity = new Vector3(0, _defaultGravityValue, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ApplyLocalGravity();
        }
    }

    private void ApplyLocalGravity()
    {
        ConstantForce constantForce = GetComponent<ConstantForce>();
        constantForce.force = new Vector3(0f, 10.00f, 0f);
    }

}
