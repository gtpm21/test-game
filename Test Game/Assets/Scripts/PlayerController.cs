using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick js;
    [SerializeField] private Animator animator;
    [SerializeField] private float MoveSpeed;

    void Start()
    {
        
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
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

    void Update()
    {
        
    }
}
