using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParamsInitializer : MonoBehaviour
{
    public int RUN_TYPE
    {
        set
        {
            GlobalParams.RUN_TYPE = value;
        }
    }
    public int GAME_MODE
    {
        set
        {
            GlobalParams.GAME_MODE = value;
        }
    }

}
