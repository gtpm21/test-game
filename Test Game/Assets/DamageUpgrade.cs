using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject popUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            popUp.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        popUp.SetActive(false);
    }
}
