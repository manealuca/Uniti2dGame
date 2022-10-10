using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 4.0f;
    public int damage = 1;

    //Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        //GetComponent<Rigidbody2D>().position+=

        /*float angle = Mathf.Atan2(this.transform.position.y, this.transform.position.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      */
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(this.gameObject, 0.1f);
        }
        else
        {
            if (collision.CompareTag("Wall"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
