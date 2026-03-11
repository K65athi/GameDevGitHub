using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab of the enemy to spawn
    public float spwanTime = 3f;

    void start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spwanTime); // Start spawning enemies after 1 second, then repeat every spwanTime seconds   
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity); // Spawn the enemy at the spawner's position with no rotation
    }
}
