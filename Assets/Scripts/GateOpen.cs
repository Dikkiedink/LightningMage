using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public float Speed = 0;
    public float ElevatorSpeed = 0;
    public float LowLimit = 5;
    public float HighLimit = 29;
    public bool Elevator = false;

    private void Update()
    {

        if (transform.position.y >= LowLimit && !Elevator)
        {
            transform.position -= (transform.up * Speed * Time.deltaTime);
        }

        else
        {
            if (transform.position.y <= HighLimit)
            {
                transform.position += (transform.up * ElevatorSpeed * Time.deltaTime);
            }
        }
    }

    public void OpenByLightning()
    {
        if (transform.position.y <= HighLimit)
        {
            transform.position += (transform.up * Speed * Time.deltaTime * 5);
        }
    }

    public void StopByLightning()
    {
        transform.position += (transform.up * Speed * Time.deltaTime);
    }

    public void MoveByLightning()
    {
        if (transform.position.y >= LowLimit)
        {
            transform.position -= (transform.up * Speed * Time.deltaTime * 5);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x, LowLimit, transform.position.z), Vector3.one);
        Gizmos.DrawWireCube(new Vector3(transform.position.x, HighLimit, transform.position.z), Vector3.one);
    }
}
