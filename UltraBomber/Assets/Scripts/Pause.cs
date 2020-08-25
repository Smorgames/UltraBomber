using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseObject;

    private bool isPaused = false;
    private Animator pauseAnimator;

    private void Start()
    {
        pauseAnimator = pauseObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            if (isPaused == true)
            {
                Time.timeScale = 0;
                pauseAnimator.SetBool("IsPaused", true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseAnimator.SetBool("IsPaused", false);
            }
        }
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseAnimator.SetBool("IsPaused", false);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
