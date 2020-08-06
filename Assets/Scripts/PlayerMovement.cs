using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1;
    public float Jump = 10;
    public CharacterController characterController;
    public float gravity;
    public float Offset;
    public float Radius;

    private float yVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Offset * Vector3.down + transform.position, Radius);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(transform.forward * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(-transform.right * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(transform.right * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(-transform.forward * Speed * Time.deltaTime);
        }

        characterController.Move(yVelocity * Time.deltaTime * Vector3.up);

        if (Physics.CheckSphere(Offset * Vector3.down + transform.position, Radius))
        {
            yVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = Jump;
                Debug.Log("Doe het NU NU NU NU NU");
            }
        }
        else
        {
            yVelocity -= gravity * 60 * Time.deltaTime;
        }
        //Debug.Log(yVelocity);
    }
}
