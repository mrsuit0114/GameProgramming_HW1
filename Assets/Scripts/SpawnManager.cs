using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float offsetX = 20f;
    public float offsetZ = 20f;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 3f);
    }

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(transform.position.x-offsetX, transform.position.x+offsetX), 19f, Random.Range(transform.position.z - offsetZ, transform.position.z+offsetZ)), Quaternion.identity);
    }
}
