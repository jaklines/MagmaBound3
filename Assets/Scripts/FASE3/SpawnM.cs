using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnM : MonoBehaviour
{
    public GameObject OtherGameObject;
    public float spawnRate = 1f;
    public float spawnRangeX = 5f;
    public PlayerMovement2 loadBoss;
    public bool ChamaOBatman = true;


    public void SpawnCoins()
    {
        float x = Random.Range(-5, 5);
        Instantiate (OtherGameObject, new Vector2(x, transform.position.y), Quaternion.identity);
        Invoke("SpawnCoins", spawnRate);
    }
}
