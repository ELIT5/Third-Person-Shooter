using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform grenadeSourse;
    public Transform player;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GrenadeCast();
        }
    }

    void GrenadeCast()
    {
        var grenade = Instantiate(grenadePrefab, grenadeSourse.position, grenadeSourse.rotation);
        grenade.GetComponent<Rigidbody>().AddForce(grenadeSourse.forward * 500);
    }
}
