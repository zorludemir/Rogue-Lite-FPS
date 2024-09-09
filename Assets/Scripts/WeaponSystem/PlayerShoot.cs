using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]private Camera playerCamera;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 50f;

    private float nextTimeToFire = 0f;
    private void Start()
    {
        playerCamera = transform.GetChild(0).GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / Player.Instance.fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.velocity = playerCamera.transform.forward * bulletSpeed;
    }
}
