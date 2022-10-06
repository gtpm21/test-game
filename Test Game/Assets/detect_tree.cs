using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_tree : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject axe;
    
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collision!");
        if (col.gameObject.CompareTag("tree"))
        {
            animator.SetBool("tree_detected", true);
            axe.tag = "axe";
        }
    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("No Collision!");
        if (col.gameObject.CompareTag("tree"))
        {
            animator.SetBool("tree_detected", false);
            axe.tag = "Untagged";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
