using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropSpawner : MonoBehaviour
{
    [SerializeField] private GameObject lootDropPrefab;
    [SerializeField] private float spawnRate = 2.5f;
    [SerializeField] private float spawnAmount = 1f;
    public float maxOffsetX = 2f;
    public float maxOffsetY = 2f;
    public int maxSpawnsAtOnce = 5;

    public int counter = 0; 

    void Start()
    {
        StartCoroutine(spawnLoot(spawnRate, spawnAmount, lootDropPrefab));
    }
    
    private IEnumerator spawnLoot(float rate,float amount, GameObject enemy)
    {
        yield return new WaitForSeconds(rate);
        float offsetX= Random.Range(-maxOffsetX, maxOffsetX);
        float offsetY = Random.Range(-maxOffsetY, maxOffsetY);
        if (counter < maxSpawnsAtOnce && counter >= 0)
        {
            counter++;
            Instantiate(lootDropPrefab ,new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z), Quaternion.identity);
        }
        StartCoroutine(spawnLoot(spawnRate, spawnAmount, lootDropPrefab));
    }
}
