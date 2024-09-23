using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public GameObject[] objects;
    public float spawnRate = 1.5f;
    public float spawnRangeX = 8f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, spawnRate);
    }

    void SpawnObject()
    {
        // Escolher um objeto aleatoriamente
        GameObject obj = objects[Random.Range(0, objects.Length)];

        // Posição randômica na horizontal
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);

        // Instanciar o objeto
        Instantiate(obj, spawnPosition, Quaternion.identity);
    }
}
