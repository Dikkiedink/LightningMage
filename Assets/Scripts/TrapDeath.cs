using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeath : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) <= 20 && transform.position.y <= 5f)
        {
            FindObjectOfType<NewPlayerMovement>().Dead = true;
        }

        //Debug.Log(Vector3.Distance(transform.position, Player.position));


        //Debug.Log(transform.position.y <= 5f);

    }
}
