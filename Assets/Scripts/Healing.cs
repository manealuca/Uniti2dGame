using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    int hpIncrease = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject, 0.15f);
            collision.GetComponent<Player>().healt+=hpIncrease;
            
        }   
    }

    public void DestroyOnContact()
    {
        Destroy(this.gameObject, 0.15F);
    }
}
