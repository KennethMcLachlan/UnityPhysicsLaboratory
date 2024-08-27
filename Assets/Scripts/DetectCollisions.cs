using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //Detect collisions with objects tagged as "Hazard"

    public float radius = 5.0f;
    public float power = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            Debug.Log("Collision detected with 'Hazard' object");

            Vector3 explosionPos = transform.position;

            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0f, ForceMode.Impulse);
                }
            }

            Destroy(gameObject);
        }
    }
}
