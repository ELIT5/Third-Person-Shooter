using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    public float heal;
    public GameObject apple;
    void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        apple.transform.Rotate(0, 1f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null && _playerHealth.playerHealth < _playerHealth.maxPlayerHealth)
        {
            _playerHealth.AddHealth(heal);
            Destroy(gameObject);
        }
    }

}
