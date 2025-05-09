using UnityEngine;
using UnityEngine.UI;

public class playerInteraction : MonoBehaviour
{
    public Transform orientation;       // where the player is and is looking
    public RawImage cursor;                // the square on the center of the screen
    public float interactDistance = 1f; // how far the player can be from something and interact with it

    Color INVIS = new Color(0, 0, 0, 0);
    Color TRANSPARENT = new Color(1, 1, 1, 0.2f);

    Ray lookRay; // a ray cast from the player camera forward.

    Rigidbody heldObject;

    // Update is called once per frame
    void Update()
    {
        // get a ray of where the player is looking
        lookRay = new Ray(orientation.position, orientation.forward);

        // if player is looking at something interactable and presses the interact key
        if(canInteract() && Input.GetButtonDown("Interact"))
        {
            // If the object is a Pickup interactable, than hold it.
            if(getInteractable() is InteractionPickup)
            {
                if(heldObject == null)
                {
                    heldObject = getInteractable().gameObject.GetComponent<Rigidbody>();
                    heldObject.useGravity = false;
                    heldObject.freezeRotation = true;
                }
                else
                {
                    heldObject.useGravity = true;
                    heldObject.freezeRotation = false;
                    heldObject = null;
                }
            }
            // Otherwise run it's interact script.
            else
                getInteractable().Interact();
        }
    }

    void FixedUpdate()
    {
        // if player is holding an object, move that object
        if(heldObject != null)
            moveHeldObject();
    }

    void moveHeldObject()
    {
        heldObject.MovePosition((orientation.position) + (orientation.forward * interactDistance));
    }

    // Checks if the player is looking at something
    bool canInteract()
    {
        // if the look ray is colliding with something
        if(getInteractable() != null)
        {
            // cursor goes white and returns true
            cursor.color = TRANSPARENT;
            return true;
        }
        // if the look ray is not colliding with anything
        else
        {
            // cursor goes black and returns false
            cursor.color = INVIS;
            return false;
        }
    }

    // gets the first object the player is looking at
    Interactable getInteractable()
    {
        // get an array of all the objects the ray is colliding with
        RaycastHit[] hits = Physics.RaycastAll(lookRay, interactDistance);

        Interactable script = null;
        // if there are objects being looked at
        if(hits.Length > 0)
        {
            // check each object hit
            for(int i = 0; i < hits.Length; i++)
            {
                // if that object has the Interactable script, store it and break;
                script = hits[i].collider.gameObject.GetComponent<Interactable>();
                if(script != null)
                    break;
            }
        }

        return script;
    }
}
