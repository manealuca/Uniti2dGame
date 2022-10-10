using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector3 direction;
    public float speed = 5.0f;
    public Transform aim;
    [SerializeField] Camera camera;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] Shield shieldPrefab;
    Vector2 facingDirection;
    bool gunLoaded = true;
    float fireRate = .65f;
    public int health = 5;
    SpriteRenderer sprite;
    //powerupstate
    public bool powerShot = false;
    public bool multiShot=false;
    public bool shield = false;
    public int powerShotTimer =0;
    public int shieldTimer =0;
    public float invulnerableTime = 3;
    public bool invulnerable = false;
    Vector3 InitialPosition;
    //public static Player Instanse;

    private void Awake()
    {
       /*if(Instanse is null)
        {
            Instanse = this;
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        InitialPosition = this.transform.position;
        shieldPrefab = GetComponentInChildren<Shield>();
        shieldPrefab.gameObject.SetActive(shield);
        UIManager.Instanse.UpdateHealth(health);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction.x = horizontal;
        direction.y = vertical;

        if (horizontal> 0) this.transform.localScale = new Vector3(-1,1,0);
        else this.transform.localScale = new Vector3(1,1,0);
        
        transform.position += direction * speed * Time.deltaTime;

        //Aim Movement
        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection.normalized;

        //float = Mathf.Clamp01(facingDirection.normalized);

        
        if (Input.GetKey(KeyCode.Mouse0) && gunLoaded) {
            gunLoaded = false;
            //conseguimos el angulo en radianes con atag2 y lo convertimos a grados con rad2deg
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);


            var InstantiateBullet = Instantiate(bulletPrefab, aim.position, targetRotation);
            InstantiateBullet.rotation = targetRotation;
            if (powerShot)
            {
                InstantiateBullet.GetComponent<Bullet>().damage = 3;
            }
            if (multiShot)
            {
                Quaternion targetRotation2 = Quaternion.AngleAxis(angle+45,Vector3.forward);
                Quaternion targetRotation3 = Quaternion.AngleAxis(angle - 45, Vector3.forward);
                var InstantiateBullet2 = Instantiate(bulletPrefab, aim.position, targetRotation2);
                var InstantiateBullet3 = Instantiate(bulletPrefab, aim.position, targetRotation3);
                Destroy(InstantiateBullet2.gameObject, 4.0f);
                Destroy(InstantiateBullet3.gameObject, 4.0f);
            }

            Destroy(InstantiateBullet.gameObject, 3.5f);
            StartCoroutine(ReloadGun(fireRate));

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
              PowerUp powerUp = collision.GetComponent<PowerUp>();
            switch (powerUp.powerUpType)
            {
                case PowerUp.PowerUpType.FireRateIncrease:
                    if (fireRate > 0.3f)
                        fireRate -= 0.15f;
                    break;
                case PowerUp.PowerUpType.PowerShot:
                   
                    powerShot = true; 
                    powerShotTimer += 15;
                    StartCoroutine(PowerShotTimer());
                    break;
                case PowerUp.PowerUpType.multiShot:
                    multiShot = true;
                    break;
                case PowerUp.PowerUpType.shield:
                    shield = true;
                    shieldPrefab.RestoreShield();
                    shieldPrefab.gameObject.SetActive(shield);
                    shieldTimer = 15;                        
                    StartCoroutine(ShieldTimmer());
                    break;
            }
            powerUp.DestroyOnContact(); 
        }

    }

    IEnumerator PowerShotTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            powerShotTimer -= 1;
            if (powerShotTimer < 1) {
                powerShot = false;
             }
        }
    }

    IEnumerator ReloadGun(float refresh)
    {
        yield return new WaitForSeconds(refresh);
        gunLoaded = true;
    }

    IEnumerator ShieldTimmer()
    {
        yield return new WaitForSeconds(1);
        shieldTimer -= 1;
        if (shieldTimer < 1) {
            shield = false;
            shieldPrefab.gameObject.SetActive(false);
        }
    }

    public IEnumerator MakeVulnerableAgain()
    {
        yield return new WaitForSeconds(invulnerableTime);
        invulnerable = false;
    }
    public void TakeDamage(int damage)
    {
        if (invulnerable) return;
        if (!shield)
        {
            health -= damage;
            UIManager.Instanse.UpdateHealth(health);
            multiShot = false;
            invulnerable = true;
            StartCoroutine(MakeVulnerableAgain());
            if (health <= 0) Death();
        }
        shieldPrefab.TakeDamage(damage);
    }
    public void Death()
    {

        sprite.enabled = false;
        GameManager.Instance.GameOver();

    }

    public void ResetStatus()
    {
        sprite.enabled = true;
        speed = 5;
        this.transform.position = InitialPosition;
        health = 5;
        invulnerable = false;
        shield = false;
        multiShot = false;
        powerShot = false;
    }
}
