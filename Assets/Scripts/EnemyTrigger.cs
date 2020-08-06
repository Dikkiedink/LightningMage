using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Transform Player;
    public bool PlayerPresence = false;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform == Player)
        {
            PlayerPresence = true;
        }
    }
}
