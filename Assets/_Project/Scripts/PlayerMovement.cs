using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; // The speed at which the player moves
    public Camera playerCamera; // Reference to the player's camera

    private Rigidbody rb; // The rigidbody component of the ball

    void Start()
    {
        // Get the rigidbody component of the ball
        rb = GetComponent<Rigidbody>();

        // If the playerCamera is not set in the inspector, try to find it in the scene
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void FixedUpdate()
    {
        // Get the horizontal and vertical input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector relative to the camera's orientation
        Vector3 cameraForward = Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = (verticalInput * cameraForward + horizontalInput * playerCamera.transform.right) * speed * Time.fixedDeltaTime;

        // Apply the movement to the ball's rigidbody
        rb.MovePosition(transform.position + movement);
    }

}
