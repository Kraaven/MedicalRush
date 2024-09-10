using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Normal speed
    [SerializeField] private float sprintSpeed = 10f; // Sprint speed
    [SerializeField] private float acceleration = 10f; // Acceleration factor
    [SerializeField] private float deceleration = 10f; // Deceleration factor
    [SerializeField] private float sprintCooldown = 5f; // Cooldown duration for sprinting
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera playerCamera; // Reference to the camera

    private Vector3 currentVelocity; // To store the current movement velocity
    private bool canSprint = true; // To check if sprinting is allowed
    private float sprintCooldownTimer = 0f; // Timer to manage sprint cooldown

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (rb != null)
        {
            rb.interpolation = RigidbodyInterpolation.Interpolate;
        }
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

        // Calculate desired movement direction
        Vector3 moveDirection = (cameraRight * horizontalInput + cameraForward * verticalInput).normalized;

        // Determine if sprinting is active
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && canSprint;

        // Set target speed based on sprinting state
        float targetSpeed = isSprinting ? sprintSpeed : speed;

        // If there's any input, accelerate towards the target velocity
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 targetVelocity = moveDirection * targetSpeed;
            currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
        }
        // If there's no input, decelerate smoothly to a stop
        else
        {
            currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, deceleration * Time.deltaTime);
        }

        // Apply movement without altering the Rigidbody's y-velocity (gravity is preserved)
        Vector3 newVelocity = new Vector3(currentVelocity.x, rb.velocity.y, currentVelocity.z);
        rb.velocity = newVelocity;

        // Handle sprint cooldown
        if (isSprinting)
        {
            // Prevent sprinting again until cooldown is complete
            canSprint = false;
            sprintCooldownTimer = sprintCooldown;
        }

        // Countdown the cooldown timer
        if (!canSprint)
        {
            sprintCooldownTimer -= Time.deltaTime;
            if (sprintCooldownTimer <= 0)
            {
                canSprint = true; // Allow sprinting again
                sprintCooldownTimer = 0; // Reset timer
            }
        }
    }
}
