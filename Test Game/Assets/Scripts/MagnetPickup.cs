using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPickup : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 20f;
    public float force = 20f;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "pickup_green" || other.tag == "pickup_pink" || other.tag == "pickup_cyan")
        {
            Transform pickup = other.transform;
            rb = other.attachedRigidbody;
            rb.AddForce((transform.position - other.transform.position).normalized * force);


            //pickup.position = Vector3.MoveTowards(pickup.position, transform.position, speed * Time.deltaTime);
        }
    }
}
