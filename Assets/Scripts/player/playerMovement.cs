using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Transform orientation;
    CharacterController controller;

    public float defaultSpeed = 3;
    float realSpeed;
    public float GRAVITY = 9.81f;
    public float YSensitivity = 1.5f;
    public float XSensitivity = 2;
    public float crouchHeight = 0.5f;
    public float crouchSpeed = 0.5f;

    float rotationY;
    float rotationX;

    public bool isMoving= false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get character controller
        controller = gameObject.GetComponent<CharacterController>();

        // Dont display mouse cursor when gaem is being played
        Cursor.lockState = CursorLockMode.Locked;

        // set real speed
        realSpeed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rotateCamera();
        moveBody();
        crouch();
    }

    void moveBody()
    {
        // get keyboard input
        float inputHoriz = Input.GetAxis("Horizontal");
        float inputVert  = Input.GetAxis("Vertical");

        // construct Vector3 with camera orientation as "forward" direction
        Vector3 direction = (orientation.forward * inputVert + orientation.right * inputHoriz) * realSpeed;
        direction.y = -GRAVITY;

        controller.Move(direction * Time.deltaTime);

        if(Mathf.Abs(inputHoriz) > 0.01f || Mathf.Abs(inputVert) > 0.01f){
            isMoving = true;
        } else{
            isMoving = false;
        }

        

        
    }

    void crouch()
    {
        // get keyboard input
        float crouchInput = Input.GetAxis("Crouch");

        //change scale
        transform.localScale = new Vector3(1 ,1 - crouchInput*crouchHeight, 1);

        //change speed
        realSpeed = defaultSpeed * (1-crouchInput*crouchSpeed);
    }

    void rotateCamera()
    {
        // get mouse input
        float lookX = Input.GetAxis("Mouse X");
        float lookY = Input.GetAxis("Mouse Y");

        // adust rotation based on mouse input
        rotationY += lookX * XSensitivity;
        rotationX -= lookY * YSensitivity;
        // prevent up/down rotation from going past 90 degrees in either direction
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // set the rotation
        orientation.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
