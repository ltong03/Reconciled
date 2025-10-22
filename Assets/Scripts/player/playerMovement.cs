using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Transform orientation;      
    [SerializeField] private Transform playerBody; 
    [SerializeField] private Transform cameraPitch;

    CharacterController controller;

    public float defaultSpeed = 3;
    float realSpeed;
    public float GRAVITY = 9.81f;
    public float YSensitivity = 1.5f; // mouse Y sensitivity
    public float XSensitivity = 2f;   // mouse X sensitivity
    public float crouchHeight = 0.5f;
    public float crouchSpeed = 0.5f;

    // Pitch clamp (adjust to taste)
    [SerializeField] float minPitch = -60f; 
    [SerializeField] float maxPitch = 70f; 

    float rotationY; // yaw
    float rotationX; // pitch

    public bool isMoving = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        realSpeed = defaultSpeed;
    }

    void Update()
    {
        rotateCamera();
        moveBody();
        crouch();
    }

    void moveBody()
    {
        float inputHoriz = Input.GetAxis("Horizontal");
        float inputVert = Input.GetAxis("Vertical");

        // use orientation's forward/right (yaw only)
        Vector3 move = (orientation.forward * inputVert + orientation.right * inputHoriz) * realSpeed;
        // simple gravity
        move.y = -GRAVITY;

        controller.Move(move * Time.deltaTime);

        isMoving = Mathf.Abs(inputHoriz) > 0.01f || Mathf.Abs(inputVert) > 0.01f;
    }

    void crouch()
    {
        float crouchInput = Input.GetAxis("Crouch");
        transform.localScale = new Vector3(1f, 1f - crouchInput * crouchHeight, 1f);
        realSpeed = defaultSpeed * (1f - crouchInput * crouchSpeed);
    }

    void rotateCamera()
    {
        // mouse delta (scaled by dt for consistent feel)
        float lookX = Input.GetAxis("Mouse X") * XSensitivity * Time.deltaTime;
        float lookY = Input.GetAxis("Mouse Y") * YSensitivity * Time.deltaTime;

        // yaw on body/orientation
        rotationY += lookX;

        // pitch on camera, then clamp
        rotationX -= lookY;
        rotationX = Mathf.Clamp(rotationX, minPitch, maxPitch);

        // apply: yaw only to orientation + body
        orientation.rotation = Quaternion.Euler(0f, rotationY, 0f);
        playerBody.rotation = Quaternion.Euler(0f, rotationY, 0f);

        // apply: pitch only to camera (LOCAL so it stacks with yaw from parent)
        if (cameraPitch != null)
            cameraPitch.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    public Vector3 GetVelocity() => controller.velocity;
}