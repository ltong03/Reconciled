using UnityEngine;
using UnityEngine.UI;

interface IInteractable
{
    void Interact();
}

public class playerInteraction : MonoBehaviour
{
    public Transform orientation;       // where the player is and is looking
    public RawImage cursor;             // the square in the center of the screen
    public float interactDistance = 3f; // how far the player can interact

    Color INVIS = new Color(0, 0, 0, 0);
    Color TRANSPARENT = new Color(1, 1, 1, 0.2f);

    void Update()
    {
        Ray r = new Ray(orientation.position, orientation.forward);

        // Draw debug ray (red = no hit by default)
        Debug.DrawRay(r.origin, r.direction * interactDistance, Color.red);

        // Default: hide cursor
        cursor.color = INVIS;

        if (Physics.Raycast(r, out RaycastHit hitInfo, interactDistance))
        {
            // Draw green ray if we hit something
            Debug.DrawRay(r.origin, r.direction * hitInfo.distance, Color.green);

            //Debug.Log("Hit: " + hitInfo.collider.gameObject.name);

            IInteractable interactObj = hitInfo.collider.GetComponentInParent<IInteractable>();

            if (interactObj != null)
            {
                // Show cursor when aiming at interactable
                cursor.color = TRANSPARENT;

                // Press E to interact
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E button was pressed!");
                    interactObj.Interact();
                }
            }
        }
    }
}