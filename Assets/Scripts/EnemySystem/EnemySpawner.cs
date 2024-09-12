using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    public GameObject enemyObj;
    private void Awake()
    {
        StartCoroutine(SpawnEnemy());
    }
    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector3 spawnPoint = new Vector3(
                transform.position.x,
                transform.position.y + 1,
                transform.position.z);
            Instantiate(enemyObj, spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
