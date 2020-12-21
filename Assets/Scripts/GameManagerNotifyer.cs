using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerNotifyer : MonoBehaviour
{
    public GameManager gameManager;
    void Notify()
    {
        gameManager.TickTime();
    }
}
