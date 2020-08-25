using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxPlayerHealth;
    [HideInInspector]
    public int currentPlayerHealth;

    public Image heartPrefab;
    public GameObject lives;
    private List<Image> _healthes;

    public GameObject gameOver;

    private AudioManager audioManager;

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        _healthes = new List<Image>();
        audioManager = AudioManager.instance;
        SetMaxHealth();
    }

    public void TakeDamage(int damage)
    {
        currentPlayerHealth -= damage;
        audioManager.PlayAudioEffect(3);

        if (currentPlayerHealth <= 0)
        {
            PlayerDeath();
            return;
        }

        for (int i = 0; i < maxPlayerHealth; i++)
        {
            _healthes[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < currentPlayerHealth; i++)
        {
            _healthes[i].gameObject.SetActive(true);
        }
    }

    private void PlayerDeath()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
        enabled = false;
    }

    private void SetMaxHealth()
    {
        for (int i = 0; i < currentPlayerHealth; i++)
        {
            Image heart = (Image)Instantiate(heartPrefab, new Vector2(10000f, 10000f), Quaternion.identity);
            _healthes.Add(heart);
            heart.transform.SetParent(lives.transform);
            heart.rectTransform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void PlusHealth()
    {
        if (currentPlayerHealth == maxPlayerHealth)
            return;

        if (currentPlayerHealth < maxPlayerHealth)
        {
            currentPlayerHealth += 1;

            for (int i = 0; i < currentPlayerHealth; i++)
            {
                _healthes[i].gameObject.SetActive(true);
            }
        }
    }
}
