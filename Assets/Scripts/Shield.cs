using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int shieldHp = 5;
    Transform parent;
    //public static Shield instance;
    // Start is called before the first frame update
    private void Awake()
    {
       //if(instance is null) instance = this;

        parent = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = parent.position;
    }
    public void TakeDamage(int damage)
    {
        shieldHp -= damage;
        if (shieldHp < 1)
        {
            this.gameObject.SetActive(false);
            GetComponentInParent<Player>().shield = false;
        }
    }
    public void RestoreShield()
    {
        shieldHp = 5;
    }
}
