using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public float interactionDistance = 3.0f; // Distance from which the player can interact
    public string interactableTag = "Interactable"; // Tag of the objects you want to interact with
    public Color rayColor = Color.red; // Color for the raycast line

    void Update()
    {
        RaycastHit hit;
        Vector3 rayDirection = transform.forward;

        // Cast a ray from the player's position forward
        if (Physics.Raycast(transform.position, rayDirection, out hit, interactionDistance))
        {
            // Draw the raycast line in the Scene view
            Debug.DrawRay(transform.position, rayDirection * hit.distance, rayColor);

            // Display the name of the object being looked at in the console
            Debug.Log("Looking at: " + hit.collider.gameObject.name);

            // Check if the object hit has the interactable tag
            if (hit.collider.CompareTag(interactableTag))
            {
                if (Input.GetKeyDown(KeyCode.E)) // Key for interaction
                {
                    // Call the interaction method on the object
                    IInteractable interactableObject = hit.collider.GetComponent<IInteractable>();
                    if (interactableObject != null)
                    {
                        interactableObject.Interact();
                    }
                    else
                    {
                        Debug.LogWarning("The object does not implement IInteractable.");
                    }
                }
            }
        }
        else
        {
            // Draw the raycast line even when not hitting any object
            Debug.DrawRay(transform.position, rayDirection * interactionDistance, rayColor);
        }
    }
}

// Interface for objects that can be interacted with
public interface IInteractable
{
    void Interact();
}