using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFaderTrigger : MonoBehaviour
{
    public GameObject sceneFader;
    public GameObject player;
    public string triggerName = "UncontrolMove1";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sceneFader.GetComponent<SceneFader>().FadeToLevel();
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Animator>().SetTrigger(triggerName);
        }
    }
}
