using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] CircleCollider2D circleCollider;
    Vector2 direction;
    float angle;
    Transform target;
    [SerializeField] int healt=1;
    public int damage = 1;
    [SerializeField] int scorePoints=100;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int randomSpawnPoint = Random.Range(0,spawnPoints.Length);
        transform.position = spawnPoints[randomSpawnPoint].transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State == GameManager.GameState.GameOver)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Move();
        }

    }
    public void Move()
    {
        direction = target.position - this.transform.position;
        this.transform.position += (Vector3)(direction/direction.magnitude) * Time.deltaTime*speed ;

    }
    public void TakeDamage(int damage)
    {
        healt-=damage;
        if(healt<=0) Death();
    }
    public void Death()
    {
        GameManager.Instance.Score += scorePoints;
        Destroy(this.gameObject);
        UIManager.Instanse.UpdateScore(GameManager.Instance.Score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }   
}
