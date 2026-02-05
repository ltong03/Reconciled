using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public Pie[] piesInScene;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;

        int totalPies = piesInScene.Length;
        QuestManager.Instance.StartQuest(totalPies);
    }
}
