using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;

    public GameObject spawnPoints;
    private Transform[] points = new Transform[24];
    public GameObject explodePrefab;

    public GameObject bulletPrefab;
    public Transform[] firePoints;
    public float bulletDestroyTime;

    private Vector2[] directionalVectors = new Vector2[8];
    private float[] angles = new float[8];
    public Transform[] firePointsDirections;

    private Vector2[] directionalVectorsRage = new Vector2[16];
    private float[] anglesRage = new float[16];
    public Transform[] firePointsDirectionsRage;

    private float timer = 0;
    public float attackRate = 3f;

    public GameObject spikyRing;

    public bool isRageStage = false;
    public bool isResisting = false;

    public int maxBossHeaelth;
    [HideInInspector]
    public int currentBossHealth;
    private string[] rageAttacks = new string[2] { "RageAttack", "RageAttack2" };

    public GameObject healthBar;
    private HealthBar healthBarComponent;

    public GameObject fakeExplodeprefab;
    public Transform[] explodePoints;
    public GameObject fire, platform;

    public GameObject openCloseDoor;

    private void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = spawnPoints.transform.GetChild(i);
        }

        for (int i = 0; i < firePoints.Length; i++)
        {
            directionalVectors[i] = (firePointsDirections[i].position - firePoints[i].position).normalized;
            angles[i] = Mathf.Atan2(directionalVectors[i].y, directionalVectors[i].x) * Mathf.Rad2Deg;
        }

        for (int i = 0; i < directionalVectorsRage.Length; i++)
        {
            directionalVectorsRage[i] = (firePointsDirectionsRage[i].position - firePoints[i / 2].position).normalized;
            anglesRage[i] = Mathf.Atan2(directionalVectorsRage[i].y, directionalVectorsRage[i].x) * Mathf.Rad2Deg;
        }

        currentBossHealth = maxBossHeaelth;
        healthBarComponent = healthBar.GetComponent<HealthBar>();
    }

    public void Attack()
    {
        for (int i = 0; i < firePoints.Length; i++)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoints[i].position, Quaternion.Euler(0f, 0f, angles[i]));
            Destroy(bullet, bulletDestroyTime);
        }
    }

    public void RageAttack()
    {
        for (int i = 0; i < firePoints.Length * 2; i++)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoints[i / 2].position, Quaternion.Euler(0f, 0f, anglesRage[i]));
            Destroy(bullet, bulletDestroyTime);
        }
    }

    public void RageAttack2()
    {
        StartCoroutine(RageAttack2Coroutine());
    }

    IEnumerator RageAttack2Coroutine()
    {
        Transform[] array = new Transform[points.Length];

        for (int i = 0; i < points.Length; i++)
        {
            int var = Random.Range(0, points.Length);
            Transform var2 = points[var];
            points[var] = points[i];
            points[i] = var2;
        }

        for (int i = 0; i < points.Length; i++)
        {
            Instantiate(explodePrefab, points[i].position, Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void SpikyRingAppear()
    {
        spikyRing.SetActive(true);
    }

    public void BossTakeDamage(int damage)
    {
        currentBossHealth -= damage;
        healthBarComponent.SetCurrentHealth();

        if (currentBossHealth <= maxBossHeaelth / 3)
        {
            animator.SetTrigger("Rage");
            isResisting = true;
            attackRate = 2.5f;
        }

        if (currentBossHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

    IEnumerator Death()
    {
        for (int i = 0; i < explodePoints.Length; i++)
        {
            GameObject explodeGO = (GameObject)Instantiate(fakeExplodeprefab, explodePoints[i].position, Quaternion.identity);
            Destroy(explodeGO, 2f);
            yield return new WaitForSeconds(0.2f);
        }

        Destroy(spikyRing);
        Destroy(fire);
        Destroy(platform);

        GetComponent<CircleCollider2D>().enabled = false;
        healthBar.SetActive(false);

        openCloseDoor.GetComponent<Animator>().SetTrigger("Open");
        enabled = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackRate && isRageStage == false)
        {
            animator.SetTrigger("Attack");
            timer = 0;
        }

        if (timer >= attackRate && isRageStage == true)
        {
            animator.SetTrigger(rageAttacks[Random.Range(0, 2)]);
            timer = 0;
        }
    }
}
