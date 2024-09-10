using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    //The Range that the Player can interact
    public float InteractRange;
    //Source of the Ray to interact
    public Transform interactorSource;
    //The Latest GameObject the player sees
    private GameObject SeenGameObject;
    //The Current Interactable Onbject
    public IInteractableObject currentInteractableObject;
    //The UI message that is displayed
    public IInteractableObject LastInteracted;

    public void Start()
    {
        interactorSource = gameObject.transform;
        LastInteracted = null;
    }

    void Update()
    {
        //Shoot out a ray
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        
        //Check if the ray has hit anything
        if (Physics.Raycast(r, out RaycastHit Hit, InteractRange))
        {
            //If the hit gameobject is something new
            if (Hit.collider.gameObject != SeenGameObject)
            {
                //set seen to the new object
                SeenGameObject = Hit.collider.gameObject;
                Debug.Log(SeenGameObject.name);
                
                //check if the gameobject is interactable
                if (SeenGameObject.TryGetComponent(out IInteractableObject interactObj))
                {
                    //Show a custom message if it can be interacted
                   // InteractMessage.text = interactObj.SeeObject();
                   currentInteractableObject = interactObj;
                   Debug.Log("This is a Interactable Object");
                }
                else
                {
                    //reset the message of the UI, and reset the interactable object
                    currentInteractableObject = null;
                }
            }
            
        }
        else
        {
            //reset the message of the UI, and reset the interactable object
            currentInteractableObject = null;
            SeenGameObject = null;
        }
        
        //Try to interact with the object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (LastInteracted != null && LastInteracted.ReInteract() )
            {
                LastInteracted.Interact();
                if (!LastInteracted.ReInteract())
                {
                    LastInteracted = null;   
                }
            }
            //Check if the seen object can be interacted with
            if (currentInteractableObject != null)
            {
                currentInteractableObject.Interact();
                LastInteracted = currentInteractableObject;
            }
        }
        
        //Debug.Log("Current: "+ currentInteractableObject+" Cache: "+ LastInteracted);
        
    }
}

