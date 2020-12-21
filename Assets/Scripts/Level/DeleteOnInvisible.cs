using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnInvisible : MonoBehaviour
{
    // Start is called before the first frame update
    public float deleteTime = 1.5f;
    void OnBecameInvisible()
    {
        Destroy(gameObject, deleteTime);
    }

}
