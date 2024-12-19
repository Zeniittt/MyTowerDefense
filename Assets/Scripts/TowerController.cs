using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int damage;
    public int maxHealth;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
        InvokeRepeating("Attack", 1.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    void Attack()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.GetComponent<BulletController>().SetupBullet(damage);
    }

    public void DescreaseHealth(int amount)
    {
        currentHealth -= amount;
    }
}
