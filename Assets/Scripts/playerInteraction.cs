using UnityEngine;
using UnityEngine.UI;

public class playerInteraction : MonoBehaviour
{
    public Transform orientation;
    public Image cursor;
    public float interactDistance = 1f;

    Ray lookRay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookRay = new Ray(orientation.position, orientation.forward);

        if(canInteract() && Input.GetButtonDown("Interact"))
            Debug.Log(getInteraction().collider);
    }

    bool canInteract()
    {
        if(Physics.Raycast(lookRay.origin, lookRay.direction, interactDistance))
        {
            cursor.color = Color.white;
            return true;
        }
        else
        {
            cursor.color = Color.black;
            return false;
        }
    }

    RaycastHit getInteraction()
    {
        RaycastHit[] hits = Physics.RaycastAll(lookRay, interactDistance);
        return hits[0];
    }
}
