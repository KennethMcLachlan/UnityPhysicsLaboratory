using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Wheels : MonoBehaviour
{
    //Reference to the Wheel Colliders using a List
    public List<WheelCollider> wheelColliders;

    //TODO: Create a method that handles apply the transform values to the wheel meshes
        //Assign the visual mesh child from each WheelCollider
        //TODO: Restructure the vehicle gameObject hierarchy to work in a parent child workflow in editor


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
        //TODO: Reposition the following code to the new method above
        Vector3 position;
        Quaternion rotation;

        //Get the position and the rotation calues of WheelCollider using GetWorldPose
        collider.GetWorldPose(out position, out rotation);

        //Set the position and rotation values of the Wheel Mesh
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;

        //Call on the new method and pass each WheelCollider from the List to the new method
    }

}
