using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteractable : MonoBehaviour, Interactable
{
    // Start is called before the first frame update
    public const string INTERACTION_TYPE = "GRAVITY";
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
    }
    public  void onInteract(GameObject source){
        if (source.GetComponent<GravityGun>())
            source.GetComponent<GravityGun>().enabled = true;
    }
    public void onEndInteract(GameObject source)
    {
        if (source.GetComponent<GravityGun>())
            source.GetComponent<GravityGun>().Disable();
    }
    public float Sigmoid (float x)
    {
            return (x) / (Mathf.Sqrt(1 + x * x));
    }
}
