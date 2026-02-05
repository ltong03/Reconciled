using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public bool questActive = false;
    public int piesTotal = 5;
    public int piesPlaced = 0;

    public event Action OnQuestStarted;
    public event Action OnPiePlaced;
    public event Action OnQuestCompleted;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void StartQuest(int totalPies)
    {
        if (questActive) return;

        questActive = true;
        piesTotal = totalPies;
        piesPlaced = 0;

        Debug.Log("Quest Started: Place the pies back on the shelf!");

        OnQuestStarted?.Invoke();
    }

    public void PlacePie()
    {
        if (!questActive) return;

        piesPlaced++;

        Debug.Log($"Pie placed! ({piesPlaced}/{piesTotal})");
        OnPiePlaced?.Invoke();

        if (piesPlaced >= piesTotal)
        {
            questActive = false;
            Debug.Log("Quest Complete! All pies placed.");
            OnQuestCompleted?.Invoke();
        }
    }
}
