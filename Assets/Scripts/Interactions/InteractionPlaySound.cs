using UnityEngine;

public class InteractionPlaySound:Interactable{
    public bool isPlaying = false;
    public string wwiseEventName;
    public override void Interact(){
        if(!isPlaying){
            PlaySong();
            Debug.Log("Play Sound");
            isPlaying = true;
        } else{
            Debug.Log("Sound Already Playing");
        }
        
        
    }
    void PlaySong(){
        AkSoundEngine.PostEvent(wwiseEventName, gameObject);
    }
    
}
