using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    public string dialogText;
    public Canvas dialogCanvas;
    public TextMeshProUGUI dialogTextVariable;
    public bool destroyHalperAfterExit = false;

    private Animator dialogCanvasAnimator;

    private void Start()
    {
        dialogCanvasAnimator = dialogCanvas.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogTextVariable.text = dialogText;
            dialogCanvasAnimator.SetTrigger("Appear");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogCanvasAnimator.SetTrigger("Disappear");
        }

        if (destroyHalperAfterExit == true)
            Destroy(gameObject);
    }
}
