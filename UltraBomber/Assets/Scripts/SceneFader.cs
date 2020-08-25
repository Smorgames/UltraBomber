using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public string levelToLoad;

    public void FadeToLevel()
    {
        GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
