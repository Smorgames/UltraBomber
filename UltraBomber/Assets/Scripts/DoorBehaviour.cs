using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public GameObject door;

    private Transform startDoorPosition;

    private AudioManager audioManager;

    private void Start()
    {
        startDoorPosition = door.transform;
        audioManager = AudioManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            door.GetComponent<Animator>().SetTrigger("Close");
            audioManager.PlayAudioEffect(4);
            Destroy(gameObject);
        }
    }
}
