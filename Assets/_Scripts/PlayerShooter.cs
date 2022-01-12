using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float _projectileForce = 20f;
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * _projectileForce, ForceMode2D.Impulse);
    }
}
