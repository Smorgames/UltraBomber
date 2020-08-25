using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float fireRate;
    public float nextShoot;
    public float bulletDestroyTime;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Vector2 directionalVector;
    private float angle;

    public Animator animator;

    private AudioSource audioSource;

    private void Start()
    {
        directionalVector = (firePoint.position - transform.position).normalized;
        angle = Mathf.Atan2(directionalVector.y, directionalVector.x) * Mathf.Rad2Deg;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time > nextShoot)
        {
            animator.SetTrigger("Shoot");
            nextShoot = Time.time + fireRate;
        }
    }

    public void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, angle));
        audioSource.Play();
        Destroy(bullet, bulletDestroyTime);
    }
}
