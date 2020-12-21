using UnityEngine;
using System.Collections;

public class PreserveGameObjectAndroid : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
