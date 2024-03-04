using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    public float Damage = 10f;

    private void Start()
    {
        Invoke("DestroyBullet", LifeTime);
    }

    void FixedUpdate()
    {
        MoveBullet();
        
    }
    void MoveBullet()
    {
        transform.position += transform.forward * Time.fixedDeltaTime * Speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        DoDamage(collision);
        DestroyBullet();
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    void DoDamage(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(Damage);

        }
    }
}
