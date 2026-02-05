using UnityEngine;

public class PieCounter : MonoBehaviour
{
    public Transform[] pieSpawnPoints;   // where pies will appear on the counter
    public GameObject piePrefab;         // what pie to show on the counter

    bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TryPlacePies();
        }
    }

    void TryPlacePies()
    {
        PieInventory inv = GameObject.FindGameObjectWithTag("Player").GetComponent<PieInventory>();

        if (!inv.AllPiesCollected)
        {
            Debug.Log("You haven't collected all the pies yet!");
            return;
        }

        Debug.Log("Placing pies on the counter...");

        foreach (Transform spawn in pieSpawnPoints)
        {
            Instantiate(piePrefab, spawn.position, spawn.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
