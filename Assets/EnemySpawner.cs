using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner enemySpawnerInstance;
    public GameObject[] objects;
    private Vector3 spawnPosition;
    [SerializeField] float enemySpawnTime = 3f;

    [SerializeField] int spawns = 0;
    [SerializeField] int spawnLimit = 10;


    void Start()
    {
        if(enemySpawnerInstance == null)
        {
            enemySpawnerInstance = this;
        }

        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (spawns <= spawnLimit)
        {
            spawnPosition.x = Random.Range(-9, 9);
            spawnPosition.y = 3.77f;
            Instantiate(objects[UnityEngine.Random.Range(0, -1)], spawnPosition, Quaternion.identity);
            spawns++;
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }
}