using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour, IInteractable
{
    public string loadSceneName;
    public void Interact()
    {
        Debug.Log("Interacted with portal!");
        if (loadSceneName != null)
        {
            SceneManager.LoadScene(loadSceneName);
        }
    }
}
