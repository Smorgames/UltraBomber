using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public GameObject panel;
    public GameObject fader;

    public void DisappearPanel()
    {
        panel.GetComponent<Disappear>().TextDisappear();
    }

    public void FadeOut()
    {
        fader.GetComponent<SceneFader>().FadeToLevel();
    }
}
