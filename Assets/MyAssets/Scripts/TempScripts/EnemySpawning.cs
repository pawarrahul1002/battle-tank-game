using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    public GameObject enemyPrefab;
    // private Vector3 position;
    private int count = 0;
    // private float timer = 0;
    private float spwanTime = 5f;
    public List<Transform> enemyPos;
    void Start()
    {
        count = 0;
        StartCoroutine(SpwanWaiting());
        count++;
    }

    void SpawningEnemy()
    {
        int num = Random.Range(0, enemyPos.Count);
        Instantiate(enemyPrefab, enemyPos[num].position, Quaternion.identity);
        enemyPos.RemoveAt(num);
    }

    IEnumerator SpwanWaiting()
    {
        SpawningEnemy();
        yield return new WaitForSeconds(spwanTime);

        if (count >= 5)
        {
            StopCoroutine(SpwanWaiting());
        }
        else
        {
            StartCoroutine(SpwanWaiting());
        }

        count++;
    }
}
