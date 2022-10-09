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
        if ((other.gameObject.CompareTag("green_tree") || other.gameObject.CompareTag("pink_tree") || other.gameObject.CompareTag("cyan_tree")) && js.Horizontal == 0 && js.Vertical == 0)
        {
            triggered = true;
            this.other = other;
            animator.SetBool("tree_detected", true);
            axe.tag = "axe";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("green_tree") || other.gameObject.CompareTag("pink_tree") || other.gameObject.CompareTag("cyan_tree"))
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
        if (triggered && !other.gameObject.activeInHierarchy)
        {
            animator.SetBool("tree_detected", false);
            axe.tag = "Untagged";
        }
    }
}
