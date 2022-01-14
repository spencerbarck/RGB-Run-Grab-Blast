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
    private float projectileForce = 20f;
    [SerializeField]
    private CameraManager cameraManager;
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        cameraManager.ScreenShake((transform.position - firePoint.position).normalized, 1f, 0.05f);
        GameObject projectile = Instantiate(projectilePrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
    }
}
