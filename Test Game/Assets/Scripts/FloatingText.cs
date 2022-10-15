using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handle behaviour of floating text pop-up
public class FloatingText : MonoBehaviour
{
    [SerializeField] private float destroyTime= 1f;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
