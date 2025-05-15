using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu:MonoBehaviour{
    public Rigidbody pie;
    public string gameSceneName;
    public string postEventSelect;
    public string postEventStartAmbience;
    public string postEventEndAmbience;

    private bool canPressStart = true;

    void Start(){
        AkSoundEngine.PostEvent(postEventStartAmbience, gameObject);
    }

    public void KnockPieDown(){
        pie.isKinematic = false;
        pie.useGravity = true;

        
        if(canPressStart){
            pie.AddForce(Vector3.forward * (1.7f + UnityEngine.Random.Range(-0.01f, 0.1f)) + Vector3.up * (2.7f + UnityEngine.Random.Range(-0.01f, 0.1f)), ForceMode.Impulse);
            Invoke(nameof(StartGame), 3.5f);
            canPressStart = false;
        }
        
        AkSoundEngine.PostEvent(postEventSelect, gameObject);
        
    }
    public void StartGame(){
        //AkSoundEngine.PostEvent(postEventEndAmbience, gameObject);
        AkSoundEngine.ExecuteActionOnEvent(postEventStartAmbience, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, 1000);
        SceneManager.LoadSceneAsync(gameSceneName);
        
    }
    
}
