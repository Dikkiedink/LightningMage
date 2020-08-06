using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDeath : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= 20)
        {
            FindObjectOfType<NewPlayerMovement>().Dead = true;
        }

    }
}
