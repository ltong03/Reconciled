using UnityEngine;

public class PieInventory : MonoBehaviour
{
    public int piesCollected = 0;
    public int totalPies = 0;

    public bool AllPiesCollected => piesCollected >= totalPies;

    public void CollectPie()
    {
        piesCollected++;
        Debug.Log($"Pie collected! {piesCollected}/{totalPies}");
    }
}

