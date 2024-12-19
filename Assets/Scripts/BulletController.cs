using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int moveSpeed;
    private int damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, 1.5f, 0) * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            enemy.DescreaseHealth(damage);

            Destroy(gameObject);
        }
    }

    public void SetupBullet(int _damage)
    {
        damage = _damage;
    }
}
