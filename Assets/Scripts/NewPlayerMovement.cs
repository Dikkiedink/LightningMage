using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class NewPlayerMovement : MonoBehaviour
{
    public Transform EndGate;
    public Transform Enemy;
    public Rigidbody Rig;

    public float Speed;
    public float JumpForce;
    public float RaycastDistance;
    public bool Dead;
    public bool DeathTrigger = false;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Rig.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        if (!Dead)
        {
            Jump();
        }

        if(Vector3.Distance(Rig.position, EndGate.position) <= 5)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
    }

    private void FixedUpdate()
    {
        if (!Dead)
        {
            Move();
        }
        else
        {
            PlayerDeath();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                Rig.AddForce(0f, JumpForce, 0f, ForceMode.Impulse);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, RaycastDistance);
    }

    private void Move()
    {
        float HAxis = Input.GetAxisRaw("Horizontal");
        float VAxis = Input.GetAxisRaw("Vertical");

        Vector3 Movement = new Vector3(HAxis, 0, VAxis) * Speed;

        Vector3 NewPosition = Rig.position + Rig.transform.TransformDirection(Movement);

        Rig.MovePosition(NewPosition);
    }

    public void PlayerDeath()
    {
        Rig.constraints = RigidbodyConstraints.None;
        if (!DeathTrigger)
        {
            Rig.AddForce((Rig.position - Enemy.position).normalized * 1000);
            DeathTrigger = true;
            FindObjectOfType<GameManager>().YouDied();
        }
    }
}
