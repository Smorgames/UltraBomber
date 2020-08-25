using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemySpeed;
    public int maxEnemyHealth;
    public int damage;
    public Animator animator;

    private int currentEnemyHealth;
    private MapDestroyer mapDestroyer;

    public int bombPower;

    [Header("MeleeAttack")]
    public float enemyAttackRange;
    public Transform attackPoint;
    public LayerMask hitLayer;

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        mapDestroyer = MapDestroyer.instance;
    }

    public void EnemyTakeDamage(int damageVariable)
    {
        currentEnemyHealth -= damageVariable;

        if(currentEnemyHealth <= 0)
        {
            GetComponent<EnemyAudio>().PlayDeathAudio();
            animator.SetTrigger("Death");
            GetComponent<Collider2D>().enabled = false;
            return;
        }
    }

    public void Explode()
    {
        mapDestroyer.Explode(transform.position, bombPower);
    }

    public void Hit()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, enemyAttackRange, hitLayer);
        foreach (Collider2D hit in hits)
        {
            hit.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, enemyAttackRange);
    }
}
