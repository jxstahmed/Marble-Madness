using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isOpen = false;

    private void Start()
    {
        startPosition = GameObject.FindGameObjectWithTag("Door").transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        GameObject.FindGameObjectWithTag("Door").transform.position = startPosition + new Vector3(0, 0.5f, 0);
        isOpen = true;
        Invoke(nameof(CloseDoor), 3);
    }

    public void CloseDoor()
    {
        GameObject.FindGameObjectWithTag("Door").transform.position = startPosition;
        isOpen = false;
    }

}
