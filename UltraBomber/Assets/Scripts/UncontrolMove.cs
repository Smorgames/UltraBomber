using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncontrolMove : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Animator>().SetTrigger("UncontrolMove2");
    }

    public void MovementActivator()
    {
        GetComponent<Movement>().enabled = true;
    }
}
