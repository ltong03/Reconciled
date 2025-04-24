using UnityEngine;

public class playerInteraction : MonoBehaviour
{
    public Transform orientation;
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
        Debug.Log(getInteraction().collider);
    }

    RaycastHit getInteraction()
    {
        if(Input.GetButtonDown("Interact"))
        {
            RaycastHit[] hits = Physics.RaycastAll(lookRay, interactDistance);
            return hits[0];
        }

        return new RaycastHit();
    }
}
