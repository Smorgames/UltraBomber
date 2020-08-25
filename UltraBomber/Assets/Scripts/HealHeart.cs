using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHeart : MonoBehaviour
{
    public int livitationSpeed = 5;

    private GameManager gameManager;
    private Vector3 startPosition;
    private float sinVariable;

    public GameObject player;
    private Player playerScript;

    private AudioManager audioManager;

    private void Start()
    {
        startPosition = transform.position;
        playerScript = player.GetComponent<Player>();
        audioManager = AudioManager.instance;
    }

    private void Update()
    {
        sinVariable += Time.deltaTime;

        transform.position = new Vector3(transform.position.x, (Mathf.Sin(sinVariable * livitationSpeed) / 10) + startPosition.y, transform.position.z);

        if (sinVariable >= 2 * Mathf.PI)
            sinVariable = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.PlusHealth();
            audioManager.PlayAudioEffect(2);
            Destroy(gameObject);
        }
    }
}
