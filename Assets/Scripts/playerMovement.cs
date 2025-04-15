using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Transform orientation;

    float rotationY;
    float rotationX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Dont display mouse cursor when gaem is being played
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse input
        float lookX = Input.GetAxis("Mouse X");
        float lookY = Input.GetAxis("Mouse Y");

        // adust rotation based on mouse input
        rotationY += lookX;
        rotationX -= lookY;
        // prevent up/down rotation from going past 90 degrees in either direction
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // set the rotation
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
