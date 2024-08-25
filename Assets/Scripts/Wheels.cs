using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    //Reference to the Wheel Colliders using a List
    public List<WheelCollider> wheelColliders;

    private void FixedUpdate()
    {
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            ApplyVisualTransform(wheelCollider);
        }
    }

    public void ApplyVisualTransform(WheelCollider collider)
    {
        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;

        //Get the position and the rotation values of WheelCollider using GetWorldPose
        collider.GetWorldPose(out position, out rotation);

        //Set the position and rotation values of the Wheel Mesh
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

}
