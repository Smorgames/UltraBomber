using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    public GameObject door;
    public float speedOfRotation;
    public float doorSpeedX;
    public float doorSpeedY;

    private bool canRotate = true;
    private float startDoorPositionY;
    private float startDoorPositionX;

    private void Start()
    {
        startDoorPositionX = door.transform.position.x;
        startDoorPositionY = door.transform.position.y;
    }

    private void Update()
    {
        if (door.transform.position.y - 1 > startDoorPositionY || door.transform.position.y + 1 < startDoorPositionY || door.transform.position.x + 1 < startDoorPositionX || door.transform.position.x - 1 > startDoorPositionX)
        {
            canRotate = false;
            GetComponent<BoxCollider2D>().enabled = false;
            return;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.Space) && canRotate)
        {
            transform.Rotate(0f, 0f, speedOfRotation * Time.deltaTime);
            door.transform.position += new Vector3(doorSpeedX * Time.deltaTime, doorSpeedY * Time.deltaTime, 0f);
        }
    }
}
