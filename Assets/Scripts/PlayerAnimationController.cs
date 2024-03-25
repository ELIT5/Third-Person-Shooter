using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _player;
    public GameObject gameOverScreen;
    public GameObject gameplayUI;
    public PlayerController playerController;
    public Animator gameOver;
    void Start()
    {
        _player = GetComponent<Animator>();
    }


    void Update()
    {
        AnimCheck();
    }
    public void Death()
    {
        gameOverScreen.SetActive(true);
        gameplayUI.SetActive(false);
        FindObjectOfType<PlayerController>().enabled = false;
        FindObjectOfType<BulletCaster>().enabled = false;
        FindObjectOfType<CameraRotation>().enabled = false;
        _player.SetBool("Die", true);
        gameOver.SetTrigger("Show");
    }
    private void AnimCheck()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _player.SetBool("W is down", true);
        }
        else
        {
            _player.SetBool("W is down", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _player.SetBool("S is down", true);
        }
        else
        {
            _player.SetBool("S is down", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _player.SetBool("A is down", true);
        }
        else
        {
            _player.SetBool("A is down", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _player.SetBool("D is down", true);
        }
        else
        {
            _player.SetBool("D is down", false);
        }
    }
}
