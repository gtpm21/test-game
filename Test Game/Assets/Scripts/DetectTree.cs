using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTree : MonoBehaviour
{
    [SerializeField] private GameObject axe;
    [SerializeField] private FloatingJoystick js;
    private Animator animator;
    private float treeDetectionSphereRadius = 1f;
    public LayerMask myLayerMask;

    private void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>();
    }

    private void Update()
    {
        DetectTreesInVicinity();
    }


    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("tree") && js.Horizontal == 0 && js.Vertical == 0)
        {
            animator.SetBool("tree_detected", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("tree"))
        {
            animator.SetBool("tree_detected", false);
        }
    }*/
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, treeDetectionSphereRadius);
    }
    void DetectTreesInVicinity()
    {

        Collider[] cols = Physics.OverlapSphere(transform.position, treeDetectionSphereRadius, myLayerMask);
        if (cols.Length != 0)
        {
             animator.SetBool("tree_detected", true);
        }
        else
        {
            animator.SetBool("tree_detected", false);
        }
    }
}
