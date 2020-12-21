using UnityEngine;

public class InitGame : MonoBehaviour
{
    public GameObject EmptyWorldGenerator;
    public GameObject LevelGenerator;
    void Awake()
    {
        switch(GlobalParams.GAME_MODE)
        {
            case Constants.GAME_MODE_EMPTY: SetLevelGenerator(true); break;
            case Constants.GAME_MODE_EASY: 
                SetLevelGenerator(false);
                LevelGenerator.GetComponent<EndlessGenerator>().enemyChance = Constants.EASY_ENEMY_CHANCE;
                break;
            case Constants.GAME_MODE_HARD:
                SetLevelGenerator(false);
                LevelGenerator.GetComponent<EndlessGenerator>().enemyChance = Constants.HARD_ENEMY_CHANCE;
                break;

        }
    }

    void SetLevelGenerator(bool isEmpty)
    {
        if(isEmpty)
        {
            LevelGenerator.SetActive(false);
            EmptyWorldGenerator.SetActive(true);
        }
        else
        {
            if (isEmpty)
            {
                EmptyWorldGenerator.SetActive(false);
                LevelGenerator.SetActive(true);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
