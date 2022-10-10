using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public enum PowerUpType
    {
        FireRateIncrease,
        PowerShot,
        multiShot,
        shield
    }
    public PowerUpType powerUpType;

    private void Update()
    {
        if(GameManager.Instance.State == GameManager.GameState.GameOver)
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyOnContact()
    {
        Destroy(this.gameObject,0.15F);
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Player.Instanse.fireRate > 0)
            {
                Player.Instanse.fireRate -= 0.15f;
            }
            Destroy(this.gameObject, 0.15f);
        }
    }*/
}
