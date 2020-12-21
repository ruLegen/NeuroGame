using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 turnVector = new Vector3();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<PlayerControls>().turnDirection = turnVector;
        }
    }
}
