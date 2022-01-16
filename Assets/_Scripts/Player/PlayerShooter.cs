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

    private float shootDelayTime = 0.25f;
    private float nextShot = 0f;
    private void Update()
    {
        if(Time.time > nextShot)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
                nextShot = Time.time + shootDelayTime;
            }else
            if(Input.GetMouseButton(0)){
                Shoot();
                nextShot = Time.time + shootDelayTime;
            }
        }
    }

    private void Shoot()
    {
        cameraManager.ScreenShake((transform.position - firePoint.position).normalized, 0.05f, 0.1f);
        GameObject projectile = Instantiate(projectilePrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
    }
}
