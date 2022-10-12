using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FloatingJoystick js;
    [SerializeField] private Animator animator;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private GameObject axe;

    public void LoadData(GameData data)
    {
        transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = transform.position;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(js.Horizontal * MoveSpeed, rb.velocity.y, js.Vertical * MoveSpeed);

        if(js.Horizontal !=0 || js.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("idling", false);
        }
        else
        {
            animator.SetBool("idling", true);
        }
                   
    }
    public void ActivateAxeTag()
    {
        axe.tag = "axe";
    }

    public void DeactivateAxeTag()
    {
        axe.tag = "Untagged";
    }
}
