using UnityEngine;

public class Spawner_nachos : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnRate = 1f;
    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        int index = Random.Range(0, objectsToSpawn.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-15f, 15f), 6f, 0);
        Instantiate(objectsToSpawn[index], spawnPosition, Quaternion.identity);
    }
}