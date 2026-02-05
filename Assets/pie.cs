using UnityEngine;

public class Pie : Interactable
{
    public override void Interact()
    {
        // Get the player's inventory
        PieInventory inv = GameObject.FindGameObjectWithTag("Player").GetComponent<PieInventory>();

        // Count it
        inv.CollectPie();

        // Remove the pie from the world
        gameObject.SetActive(false);
    }
}
