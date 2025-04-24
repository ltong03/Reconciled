using UnityEngine;
using UnityEngine.UI;

public class playerInteraction : MonoBehaviour
{
    public Transform orientation;       // where the player is and is looking
    public Image cursor;                // the square on the center of the screen
    public float interactDistance = 1f; // how far the player can be from something and interact with it

    Ray lookRay; // a ray cast from the player camera forward.

    // Update is called once per frame
    void Update()
    {
        // get a ray of where the player is looking
        lookRay = new Ray(orientation.position, orientation.forward);

        // if player is looking at something interactable and presses the interact key
        if(canInteract() && Input.GetButtonDown("Interact"))
            // print the object player is looking at
            Debug.Log(getInteraction().collider);
    }

    // Checks if the player is looking at something
    bool canInteract()
    {
        // if the look ray is colliding with something
        if(Physics.Raycast(lookRay.origin, lookRay.direction, interactDistance))
        {
            // cursor goes white and returns true
            cursor.color = Color.white;
            return true;
        }
        // if the look ray is not oclliding with anythgin
        else
        {
            // cursor goes black and returns false
            cursor.color = Color.black;
            return false;
        }
    }

    // gets the first object the player is looking at
    RaycastHit getInteraction()
    {
        // get an array of all the objects the ray is colliding with
        RaycastHit[] hits = Physics.RaycastAll(lookRay, interactDistance);
        // return the first one
        return hits[0];
    }
}
