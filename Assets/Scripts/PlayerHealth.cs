using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerHealth = 100;
    public float maxPlayerHealth;
    public RectTransform healthBar;

    public PlayerAnimationController anim;
    public GameObject automate;


    private void Start()
    {
        maxPlayerHealth = playerHealth;
        DrawHealthBar();
    }



    public void DealDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            anim.Death();
            Destroy(automate);
        }
        DrawHealthBar();
    }

    public void AddHealth(float amount)
    {
        playerHealth += amount;
        playerHealth = Mathf.Clamp(playerHealth, 0, maxPlayerHealth);
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        healthBar.anchorMax = new Vector2(playerHealth / maxPlayerHealth, 1);
    }
}
