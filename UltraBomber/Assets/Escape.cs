using UnityEngine;

public class Escape : MonoBehaviour
{
    public GameObject sceneFaderGameObject;
    private SceneFader sceneFader;

    private void Start()
    {
        sceneFader = sceneFaderGameObject.GetComponent<SceneFader>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneFader.FadeToLevel();
        }
    }
}
