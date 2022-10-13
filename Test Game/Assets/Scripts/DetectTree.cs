using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handling tree detection and chopping animation activation.
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

    void DetectTreesInVicinity()
    {

        Collider[] cols = Physics.OverlapSphere(transform.position, treeDetectionSphereRadius, myLayerMask);
        if (cols.Length != 0 && js.Horizontal == 0 && js.Vertical == 0)
        {
             animator.SetBool("tree_detected", true);
        }
        else
        {
            animator.SetBool("tree_detected", false);
        }
    }
}
