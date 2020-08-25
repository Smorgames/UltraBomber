using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject player;
    private Movement playerMovement;
    private BombSpawner playerBombSpawner;

    public GameObject powerUpEffect;

    private AudioManager audioManager;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<Movement>();
        playerBombSpawner = player.GetComponent<BombSpawner>();
        audioManager = AudioManager.instance;
    }

    public void UpMoveSpeed()
    {
        playerMovement.IncreaseMoveSpeed();
    }

    public void UpBombAmount()
    {
        playerBombSpawner.bombAmountIncrease();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioManager.PlayAudioEffect(0);
            int var = Random.Range(0, 2);

            if (var == 0)
                UpMoveSpeed();
            else
                UpBombAmount();
            GameObject effect = (GameObject)Instantiate(powerUpEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
            Destroy(gameObject);
        }
    }
}
