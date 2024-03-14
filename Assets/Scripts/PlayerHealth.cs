using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerHealth = 100;
    private float _maxPlayerHealth;
    public RectTransform healthBar;
    public GameObject gameOverScreen;
    public GameObject gameplayUI;

    private void Start()
    {
        _maxPlayerHealth = playerHealth;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        playerHealth -= damage * Time.deltaTime;
        if (playerHealth <= 0)
        {
            Death();
        }
        DrawHealthBar();
    }
    private void Death()
    {
        gameOverScreen.SetActive(true);
        gameplayUI.SetActive(false);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<BulletCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }

    private void DrawHealthBar()
    {
        healthBar.anchorMax = new Vector2(playerHealth / _maxPlayerHealth, 1);
    }
}
