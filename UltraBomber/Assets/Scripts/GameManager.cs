using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int collectedInstruments;

    public Text collectedInstrumentsUI;

    public GameObject openCloseDoor;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("More than one GameManager on  the scene");
        instance = this;
    }

    private void Start()
    {
        collectedInstruments = 0;
        collectedInstrumentsUI.text = "Collected 0 / 8 items";
    }

    public void AddInstrumentAmount()
    {
        collectedInstruments += 1;
        collectedInstrumentsUI.text = "Collected " + collectedInstruments.ToString() + " / 8 items";
        if (collectedInstruments == 8)
            openCloseDoor.GetComponent<Animator>().SetTrigger("Open");
    }
}
