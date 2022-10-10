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

    private void Update()
    {
        if (GameManager.Instance.State == GameManager.GameState.GameOver)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject, 0.15f);

            collision.GetComponent<Player>().health += hpIncrease;
            if (collision.GetComponent<Player>().health > 5) collision.GetComponent<Player>().health = 5;

            UIManager.Instanse.UpdateHealth(collision.GetComponent<Player>().health);
        }   
    }

    public void DestroyOnContact()
    {
        Destroy(this.gameObject, 0.15F);
    }
}
