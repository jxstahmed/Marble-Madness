using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    [SerializeField] float force = 4f;

    private Rigidbody player; // The rigidbody component of the ball

    void Start()
    {
        // Get the rigidbody component of the ball
        player = GetComponent<Rigidbody>();

        // If the playerCamera is not set in the inspector, try to find it in the scene
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void FixedUpdate()
    {
        // speed multiplayer
        Vector3 absoluteMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * force * Time.deltaTime * 100f;
        // get Vector3 sample of camera
        Vector3 cameraVector = playerCamera.transform.rotation * Vector3.forward;
        // apply the direction of the camera and normalize it
        Vector3 cameraDirection = new Vector3(cameraVector.x, 0f, cameraVector.z).normalized;
        // rotate the absolute movement in accordance with the camera rotation
        var playerMovement = Quaternion.FromToRotation(Vector3.forward, cameraDirection) * absoluteMovement;
        // apply the force
        player.AddForce(playerMovement);
    }

}
