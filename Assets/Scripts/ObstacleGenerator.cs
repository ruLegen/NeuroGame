using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject[] obstacles;
    public float chance = 50;
    void Start()
    {
        if(Random.Range(0,100) < chance)
            Instantiate(obstacles[Random.Range(0, obstacles.Length * 4) % obstacles.Length],gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
