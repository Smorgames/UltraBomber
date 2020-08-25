using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private MapDestroyer mapDestroyer;

    public GameObject bombCollider;

    public int bombPower;

    private GameObject player;
    private BombSpawner playerBombSpawner;

    private void Start()
    {
        mapDestroyer = MapDestroyer.instance;
        player = GameObject.FindWithTag("Player");
        playerBombSpawner = player.GetComponent<BombSpawner>();
    }

    public void Explode()
    {
        mapDestroyer.Explode(transform.position, bombPower);
        playerBombSpawner.bombAmountIncrease();
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bombCollider.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
