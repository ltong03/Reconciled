using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu:MonoBehaviour{
    public Rigidbody pie;
    public string gameSceneName;

    public void KnockPieDown(){
        pie.isKinematic = false;
        pie.useGravity = true;
        float forceRandomizer;

        pie.AddForce(Vector3.forward * (1.7f + UnityEngine.Random.Range(-0.01f, 0.1f)) + Vector3.up * (2.7f + UnityEngine.Random.Range(-0.01f, 0.1f)), ForceMode.Impulse);

        Invoke(nameof(StartGame), 5f);
        
    }
    public void StartGame(){
        SceneManager.LoadSceneAsync("InteractTest");
    }
    
}
