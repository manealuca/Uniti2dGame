using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnController : MonoBehaviour
{
    [Range(0,10),SerializeField] float spawnRate = 1.0f;
    [SerializeField]GameObject[] EnemyuPrefab;
    [SerializeField] float spawnRadius = 7.0f;
    //Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
       // spawnPoint = this.transform;
        StartCoroutine(SpawnNewEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetInitialStatus()
    {/*
        Enemy[]EnemyInstantiate = FindObjectsOfType<Enemy>();
        foreach(var item  in EnemyInstantiate)
        {
            Destroy(item);
        }*/
    }
    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/spawnRate);
            float random = Random.Range(0.0f, 1.0f);
            if( random<GameManager.Instance.dificulty * 0.1f)
            {
                Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
                Instantiate(EnemyuPrefab[0], randomPosition, Quaternion.identity);
            }
              
            //else
                //Instantiate(EnemyuPrefab[1]);
        }
    }
}
