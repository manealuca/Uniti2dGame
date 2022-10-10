using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    Player player;
    [SerializeField] float speedReductionRatio = 0.2f;
    float originalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        originalSpeed = player.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.speed *= speedReductionRatio;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.speed = originalSpeed;
        }
        
    }


}
