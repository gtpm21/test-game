using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_tree : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject axe;
    [SerializeField] private FloatingJoystick js;
    bool triggered = false;
    Collider other;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("tree") && js.Horizontal == 0 && js.Vertical == 0)
        {
            triggered = true;
            this.other = other;
            animator.SetBool("tree_detected", true);
            Invoke("ActivateTag", 0.5f);
            //Invoke("DeactivateTag", 1);
        }
    }

    private void ActivateTag()
    {
        if (axe.tag == "Untagged")
        {
            axe.tag = "axe";
        }
    }

    private void DeactivateTag()
    {
        if (axe.tag == "axe")
        {
            axe.tag = "Untagged";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("tree"))
        {
            animator.SetBool("tree_detected", false);
            axe.tag = "Untagged";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && !other.gameObject.activeInHierarchy)
        {
            animator.SetBool("tree_detected", false);
            axe.tag = "Untagged";
        }
    }
}
