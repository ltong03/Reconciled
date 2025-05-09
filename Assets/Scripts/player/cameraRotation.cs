using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public Transform orientation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Sets the cameras rotation to the orientations rotation
        GetComponent<Transform>().rotation = orientation.rotation;
    }
}
