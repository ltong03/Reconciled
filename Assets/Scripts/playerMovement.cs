using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Transform orientation;
    CharacterController controller;

    public float SPEED = 4;
    public float GRAVITY = 9.81f;

    float rotationY;
    float rotationX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        // Dont display mouse cursor when gaem is being played
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotateCamera();
        moveBody();
    }

    void moveBody()
    {
        float inputHoriz = Input.GetAxis("Horizontal");
        float inputVert  = Input.GetAxis("Vertical");

        Vector3 direction = (orientation.forward * inputVert + orientation.right * inputHoriz) * SPEED;
        direction.y = -GRAVITY;

        controller.Move(direction * Time.deltaTime);
    }

    void rotateCamera()
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
