using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public Terrain terrain;
    private int numberOfCoins = 200;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        Collider coinCollider = coin.GetComponent<Collider>();
        //float coinHeight = coinCollider != null ? coinCollider.bounds.extents.y : 2f;
        float coinHeight = 1f;

        for (int i = 0; i < numberOfCoins; i++)
        {
            float randomX = Random.Range(0, terrain.terrainData.size.x);
            float randomZ = Random.Range(0, terrain.terrainData.size.z);
            float yPosition = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));
            float adjustedY = yPosition + coinHeight;

            Vector3 spawnPosition = new Vector3(randomX, adjustedY, randomZ);
            Instantiate(coin, spawnPosition, Quaternion.identity);
        }
    }
}
