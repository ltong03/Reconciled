using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour{
    public string sceneName;

    private void OnTriggerEnter(Collider portal){
        Debug.Log("OnTrigger Triggered");
        if(portal.CompareTag("Player")){
            Debug.Log("Switching Scenes");
            SceneManager.LoadScene(sceneName);
        }
    }

}
