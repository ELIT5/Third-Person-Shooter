using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform bulletSource;
    public AudioSource shoot;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, bulletSource.transform.position, bulletSource.transform.rotation);
            shoot.Play();
        }
    }
}
