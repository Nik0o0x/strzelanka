using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerZombie : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount <= 2)
        {
            xPos = Random.Range(-10, 5);
            zPos = Random.Range(-10, 5);
            Instantiate(theEnemy, new Vector3(xPos, 4, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);
            EnemyCount += 1;
        }
    }
}