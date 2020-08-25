using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float explodeRadius;
    public LayerMask hitLayer;
    public int damageAmount;

    private GameObject boss;
    private Boss bossComponent;

    private void Start()
    {
        Destroy(gameObject, 2f);
        boss = GameObject.FindWithTag("Boss");
        bossComponent = boss.GetComponent<Boss>();
    }

    public void Damage()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explodeRadius, hitLayer);
        foreach (Collider2D hit in hitObjects)
        {
            if (hit.GetComponent<Player>() != null)
                hit.GetComponent<Player>().TakeDamage(damageAmount);
            if (hit.GetComponent<EnemyStats>() != null)
                hit.GetComponent<EnemyStats>().EnemyTakeDamage(damageAmount);
            if (hit.GetComponent<Boss>() != null && !bossComponent.isResisting)
                hit.GetComponent<Boss>().BossTakeDamage(damageAmount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }
}
