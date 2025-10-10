using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform chairSitPoint;
    public GameObject player;
    public CharacterController controller;
    public RockingChair rockingChair;  // Reference to the RockingChair script

    public KeyCode interactKey = KeyCode.E;

    private bool isNearChair = false;
    private bool isSitting = false;

    void Update()
    {
        if (isNearChair && Input.GetKeyDown(interactKey))
        {
            if (!isSitting)
                SitInChair();
            else
                StandUp();
        }
    }

    void SitInChair()
    {
        controller.enabled = false;
        player.transform.position = chairSitPoint.position;
        player.transform.rotation = chairSitPoint.rotation;
        isSitting = true;
        if (rockingChair != null)
            rockingChair.StartRocking();
    }

    void StandUp()
    {
        player.transform.position += player.transform.forward * 1.5f;
        controller.enabled = true;
        isSitting = false;
        if (rockingChair != null)
            rockingChair.StopRocking();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isNearChair = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isNearChair = false;
                }
}