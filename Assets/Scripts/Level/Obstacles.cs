using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yes");
        if (other.gameObject.tag == "Player")
        {
            KillableInterface kill = other.gameObject.GetComponent<KillableInterface>();
            kill.onDie();
        }

    }

}
