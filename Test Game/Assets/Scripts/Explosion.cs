using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionMinForce;
    public float explosionMaxForce;
    public float radius;

    private void Start()
    {
        Explode();
    }

    public void Explode()
    {
        foreach(Transform piece in transform)
        {
            var rb = piece.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(Random.Range(explosionMinForce, explosionMaxForce), transform.position, radius);
                Debug.Log("Explosion!");
            }
        }
    }
}
