using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    public int livitationSpeed = 5;

    private GameManager gameManager;
    private Vector3 startPosition;
    private float sinVariable;

    private AudioManager audioManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        audioManager = AudioManager.instance;
        startPosition = transform.position;
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
            gameManager.AddInstrumentAmount();
            audioManager.PlayAudioEffect(1);
            Destroy(gameObject);
        }
    }
}
