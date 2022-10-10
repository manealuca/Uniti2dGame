using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject checkPointPrefab;
    [SerializeField] int spawnRate = 10;
    [SerializeField] float spawnRadius = 7.0f;
    [SerializeField] GameObject [] powerUpPrefab;
    [SerializeField] int powerUpSpawnRate = 20;
    [SerializeField] GameObject HealingPrefab;
    [SerializeField] int HealingSpawnRate = 20;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItemRoutine());
        StartCoroutine(SpawnPowerUpRputine());
        StartCoroutine(HealingSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HealingSpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(HealingSpawnRate);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Instantiate(HealingPrefab, randomPosition, Quaternion.identity);
        }
    }

    IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Vector2 randomPosition = Random.insideUnitCircle*spawnRadius;
            Instantiate(checkPointPrefab,randomPosition,Quaternion.identity);
        }

    }

    IEnumerator SpawnPowerUpRputine()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnRate);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            int random = Random.Range(0, powerUpPrefab.Length);
            Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);
        }
    }

    public void RestartInitialStatus()
    {
        /*PowerUp[] powerUpsIntantiate = FindObjectsOfType<PowerUp>();
        Healing[] HealingInstantiate = FindObjectsOfType<Healing>();
        CheckPoint[] CheckpointInstantiate = FindObjectsOfType<CheckPoint>(); 
        foreach (var item in powerUpsIntantiate)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in HealingInstantiate)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in CheckpointInstantiate)
        {
            Destroy(item.gameObject);
        }*/
    }
}
