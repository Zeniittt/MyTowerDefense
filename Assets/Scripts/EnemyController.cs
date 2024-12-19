using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    public int damage;
    public int maxhealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxhealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         rb.velocity = new Vector2(0, -moveSpeed);

        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            moveSpeed = 0;
            StartCoroutine(Attack(1.5f, collision.GetComponent<TowerController>()));
        } 
    }

    public void DescreaseHealth(int amount)
    {
        currentHealth -= amount;
    }


    IEnumerator Attack(float delay, TowerController tower)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("enemy attack");
        tower.DescreaseHealth(damage);
    }
}
