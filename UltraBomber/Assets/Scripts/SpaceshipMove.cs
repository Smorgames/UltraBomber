using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipMove : MonoBehaviour
{
    private float x;

    private void Update()
    {
        x += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(x), transform.position.z);

        if (Mathf.Sin(x) >= 2 * Mathf.PI)
            x = 0;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
