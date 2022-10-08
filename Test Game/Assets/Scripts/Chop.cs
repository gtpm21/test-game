using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("green_tree") || other.gameObject.CompareTag("pink_tree") || other.gameObject.CompareTag("cyan_tree")) && other.gameObject.activeInHierarchy && gameObject.tag == "axe") 
        { 
        other.gameObject.GetComponent<TreeID>().isChopped = true;
        }
    }
}
