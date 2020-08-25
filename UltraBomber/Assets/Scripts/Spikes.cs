using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Animator animator;

    private BoxCollider2D boxCollider;

    private AudioSource audioSource;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SpikesAppear()
    {
        boxCollider.enabled = true;
        audioSource.Play();
    }

    public void SpikesDisappear()
    {
        boxCollider.enabled = false;
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(1);
        }
    }
}
