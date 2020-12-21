using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float r = Random.Range(0, 255)/255f;
        float g = Random.Range(0, 255) / 255f;
        float b = Random.Range(0, 255) / 255f;
        gameObject.GetComponent<Renderer>().material.color = new Color(r,g,b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
