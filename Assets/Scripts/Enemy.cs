using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Properties")]
    public float health = 100;
    public float shotCounter;
    public float minTimeBetweenShots = 0.2f;
    public float maxTimeBetweenShots = 3f;

    [Header("ExplosionFX")]
    [Tooltip("Object's tag name that will be called to animate.")]
    public string effectTagName;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownToShoot();
    }

    private void CountDownToShoot()
    {
        shotCounter -= Time.deltaTime;
        if ( shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = ObjectPool.SharedInstance.GetPooledObject("EnemyLaser");
        if (laser != null)
        {
            laser.transform.position = transform.position;
            laser.transform.rotation = Quaternion.identity;
            laser.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        if ( damageDealer)
        {
            TakeDamage(damageDealer.GetDamage());

            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject objFX = ObjectPool.SharedInstance.GetPooledObject(effectTagName);
            if (objFX)
            {
                objFX.transform.position = transform.position;
                objFX.transform.rotation = Quaternion.identity;
                objFX.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
