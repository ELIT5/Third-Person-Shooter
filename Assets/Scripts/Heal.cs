using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth _playerHealth;
    public float heal;
    public GameObject healGameObject;
    void Start()
    {
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        transform.Rotate(0, 1f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && _playerHealth.playerHealth < _playerHealth.maxPlayerHealth)
        {
            _playerHealth.AddHealth(heal);
            Destroy(healGameObject);
        }
    }

}
