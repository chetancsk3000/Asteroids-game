using UnityEngine;

/// <summary>
/// The Spawner class manages spawning of obstacles like meteorites at regular intervals.
/// It creates obstacles at random positions within a specified horizontal range along the top of the screen.
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject meteoritePrefab1, meteoritePrefab2;
    public float spawnInterval = 2f;

    // Define the horizontal range for spawning
    public float minX = -5f;
    public float maxX = 5f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnMeteorite();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnMeteorite()
    {
        // Randomly select one of the two meteorites to spawn
        GameObject selectedMeteorite = Random.value < 0.5f ? meteoritePrefab1 : meteoritePrefab2;

        // Ensure the meteorite spawns within the defined horizontal range (minX to maxX)
        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), 6f);

        // Spawn the selected meteorite at the random position
        Instantiate(selectedMeteorite, spawnPosition, Quaternion.identity);
    }
}