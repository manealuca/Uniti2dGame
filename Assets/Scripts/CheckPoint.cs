using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int addedTime = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.time += addedTime;
            Console.Write(GameManager.Instance.time);
            Destroy(this.gameObject,0.1f);
            
        }
    }
}
