using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPickup : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float speed;
    public float force = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "pickup_green" || other.tag == "pickup_pink" || other.tag == "pickup_cyan")
        {
            Transform pickup = other.transform;
            m_Rigidbody = other.attachedRigidbody;
            m_Rigidbody.AddForce((transform.position - other.transform.position).normalized * force);


            //pickup.position = Vector3.MoveTowards(pickup.position, transform.position, speed * Time.deltaTime);
        }
    }
}
