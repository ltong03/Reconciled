using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu:MonoBehaviour{
    public Rigidbody pie;
    public string gameSceneName;
    public string postEventSelect;
    public string postEventStartAmbience;

    private bool canPressStart = true;

    void Start(){
        AkSoundEngine.PostEvent(postEventStartAmbience, gameObject);
    }

    public void KnockPieDown(){
        pie.isKinematic = false;
        pie.useGravity = true;

        
        if(canPressStart){
            float secretEndChance = UnityEngine.Random.Range(0f, 1f);
            if(secretEndChance > 0.01f){
                pie.AddForce(Vector3.forward * (1.7f + UnityEngine.Random.Range(-0.01f, 0.1f)) + Vector3.up * (2.7f + UnityEngine.Random.Range(-0.01f, 0.02f)), ForceMode.Impulse);
                Invoke(nameof(StartGame), 3.5f);
                canPressStart = false;
                AkSoundEngine.ExecuteActionOnEvent(postEventStartAmbience, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, 1000);
            } else{
                pie.AddForce(Vector3.forward * (1.7f + UnityEngine.Random.Range(-0.01f, 0.1f)) + Vector3.up * (2.7f + UnityEngine.Random.Range(-1f, 1f)), ForceMode.Impulse);
                //SECRET END
            }
            
        }
        
        AkSoundEngine.PostEvent(postEventSelect, gameObject);
        
    }
    public void StartGame(){
        //AkSoundEngine.PostEvent(postEventEndAmbience, gameObject);
        AkSoundEngine.ExecuteActionOnEvent(postEventStartAmbience, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, 1000);
        // Changing start of game to physics based collision of pie on collider. This is symbolic of the story. There is a small change the pie won't go out of the window. If this happens, the game won't start. Cool right? 
        // Maybe we can transition to a secret ending if pie doesn't 

        //SceneManager.LoadSceneAsync(gameSceneName);
        
    }
    
}
