using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Terrain terrain;
    private int numberOfEnemies = 200;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float randomX = Random.Range(0, terrain.terrainData.size.x);
            float randomZ = Random.Range(0, terrain.terrainData.size.z);
            float yPosition = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));
            Vector3 spawnPosition = new Vector3(randomX, yPosition, randomZ);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
}
