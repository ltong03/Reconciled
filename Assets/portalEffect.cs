using UnityEngine;

public class portalEffect : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portalCamera;
    public Transform otherPortal;

    void Start()
    {
        // Lock camera at the other portal
        portalCamera.position = otherPortal.position;
    }

    void Update()
    {
        if (!playerCamera || !portalCamera || !otherPortal)
            return;

        // Only copy Y rotation (left/right look)
        float yRotation = playerCamera.eulerAngles.y;

        // Apply it relative to the other portal
        portalCamera.rotation = Quaternion.Euler(0, yRotation + 180f, 0);

        // Match FOV
        Camera pc = playerCamera.GetComponent<Camera>();
        Camera rc = portalCamera.GetComponent<Camera>();

        if (pc && rc)
            rc.fieldOfView = pc.fieldOfView;
    }
}