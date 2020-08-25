using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] deathAudio;
    public AudioClip[] growlAudio;

    private AudioClip currentDeathAudio;
    private AudioClip currentGrowlAudio;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentDeathAudio = deathAudio[Random.Range(0, 3)];
        currentGrowlAudio = growlAudio[Random.Range(0, 3)];
    }

    public void PlayDeathAudio()
    {
        audioSource.PlayOneShot(currentDeathAudio);
    }

    public void PlayGrowlAudio()
    {
        audioSource.PlayOneShot(currentGrowlAudio);
    }
}
