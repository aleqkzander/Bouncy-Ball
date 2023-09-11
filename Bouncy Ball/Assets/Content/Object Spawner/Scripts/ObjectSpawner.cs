using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objects;

    private int spawnedCounter = 0;
    private readonly int objectsToCount = 10;

    private float spawnTime = 2f;
    private readonly float minSpawnTime = 0.5f;
    private readonly float reduceSpawnTimeAmount = 0.1f;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(spawnTime);
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        SetTheCounter();

        // Get a random object from the list
        GameObject spawnObject = objects[Random.Range(0, objects.Count)];

        // Spawn that object in range
        float spawnField = Random.Range(-7.74f, 7.74f);
        Instantiate(spawnObject, new Vector2(spawnField, gameObject.transform.position.y), Quaternion.identity);

        StartCoroutine(Spawner());
    }

    private void SetTheCounter()
    {
        // Track the amount of objects spawned
        spawnedCounter++;

        if (spawnedCounter == objectsToCount && spawnTime > minSpawnTime)
        {
            // Reset the counter
            spawnedCounter = 0;

            // Reduce the required time for spawning objects
            spawnTime -= reduceSpawnTimeAmount;
        }
    }
}
