using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform firePoint;
    public EnemyBehav ProjectilePreFab;
    public Transform LaunchOffset;

    float enemySpawnTime;
    float randomSpawning;
    public int enemyCount = 0;
    [SerializeField] public int maxEnemy;
    bool canSpawn = true;

    private void start()
    {
    }
    private void Update()
    {
        if (enemyCount > maxEnemy)
        {
            canSpawn = false;
        }
        else if (enemyCount < maxEnemy)
        {
            canSpawn = true;
        }

        enemySpawnTime += Time.deltaTime;
        //shits not spawning fully randomly but only at lowest??
        randomSpawning = Random.Range(5f, 8f);

        if (enemySpawnTime > randomSpawning && canSpawn == true)
        {
            Instantiate(ProjectilePreFab, LaunchOffset.position, transform.rotation);
            enemySpawnTime = 0;
            enemyCount++;
        }
    }
}
