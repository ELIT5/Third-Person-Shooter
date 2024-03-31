using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 30;
    public float maxSize = 5;
    public float explosionSpeed;
    public AudioSource puk;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        puk.Play();
    }

    private void Update()
    {
        Grow();
    }

    void Grow()
    {
        transform.localScale += Vector3.one * Time.deltaTime * explosionSpeed;
        if (transform.localScale.x > maxSize)
        {
            DeleteExplosion();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(damage);
        }
    }

    void DeleteExplosion()
    {
        Destroy(gameObject);
    }
}
