using UnityEngine;

public class EndlessGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject initialPlatform;
    public GameObject[] platforms;
    public Vector3 newSpawnPosition = new Vector3();
    public float spawnDistance = 100;
    public int initialSpawnCount = 7;
    public int enemyChance = 10;


    public Vector3 turnVector = Vector3.forward;
    void Start()
    {
        foreach (GameObject platform in platforms)
        {
            if(platform.GetComponent<ObstacleGenerator>() != null)  // Check if it Platform not Enviroment
                platform.GetComponent<ObstacleGenerator>().chance = enemyChance;
        }

        for (int i = 0; i< initialSpawnCount; i++)
        {
            SpawnNewPlatform(initialPlatform);
        }
}
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToSpawnPoint = Vector3.Distance(player.transform.position, newSpawnPosition);
        if (distanceToSpawnPoint <= spawnDistance)
            SpawnNewPlatform(platforms[Random.Range(0, platforms.Length * 4) % platforms.Length]);
    }

    public GameObject SpawnNewPlatform(GameObject platform)
    {
        GameObject spawnedPlatform = Instantiate(platform, newSpawnPosition, new Quaternion());
        //spawnedPlatform.GetComponentInChildren<TurnTrigger>().turnVector = turnVector;
        newSpawnPosition = spawnedPlatform.transform.position +spawnedPlatform.GetComponentInChildren<MeshCollider>().bounds.size.z * turnVector;
        return spawnedPlatform;
    }

   
}
