using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed; // You can adjust this as needed
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera playerCamera; // Reference to the camera

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Use FixedUpdate for physics-based movement
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction relative to the camera
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0; // Ensure movement is only on the X-Z plane
        cameraForward.Normalize(); // Normalize to get a direction vector

        Vector3 cameraRight = playerCamera.transform.right;
        cameraRight.y = 0; // Ensure movement is only on the X-Z plane
        cameraRight.Normalize(); // Normalize to get a direction vector

        // Calculate movement direction
        Vector3 moveDirection = (cameraRight * horizontalInput + cameraForward * verticalInput).normalized;

        // Apply movement without altering the Rigidbody's y-velocity (gravity is preserved)
        Vector3 moveVec = moveDirection * speed;
        Vector3 newVelocity = new Vector3(moveVec.x, rb.velocity.y, moveVec.z);

        // Set the velocity
        rb.velocity = newVelocity;
    }
}