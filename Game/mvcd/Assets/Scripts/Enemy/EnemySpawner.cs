using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject walkerPrefab;
    
    private float spawnRate = 2.5f;
    private float spawnAmount = 2f;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawnRate, spawnAmount, walkerPrefab));
    }
    
    private IEnumerator spawnEnemy(float rate,float amount, GameObject enemy)
    {
        yield return new WaitForSeconds(rate);
        for (int i = 0; i < amount; i++)
        {
            GameObject newEnemy = Instantiate(walkerPrefab, transform.position, Quaternion.identity);
        }
        StartCoroutine(spawnEnemy(spawnRate, spawnAmount, walkerPrefab));
    }
}
