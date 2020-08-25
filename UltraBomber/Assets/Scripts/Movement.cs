using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator playerAnimator;

    private Vector2 movement;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);
        if (audioSource != null)
        {
            if (movement.sqrMagnitude != 0 && !audioSource.isPlaying)
                audioSource.Play();
            if (movement.sqrMagnitude == 0 && audioSource.isPlaying)
                audioSource.Stop();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void IncreaseMoveSpeed()
    {
        moveSpeed += 1f;
    }
}
