using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockActivator : MonoBehaviour
{
    public GameObject block;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            block.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(gameObject);
        }
    }
}
