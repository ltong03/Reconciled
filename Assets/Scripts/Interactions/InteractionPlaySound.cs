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
        AkSoundEngine.PostEvent(wwiseEventName, 
        gameObject,
        (uint)AkCallbackType.AK_EndOfEvent,
        EndAudioCallback,
        null);  
    }
    private void EndAudioCallback(object note,
    AkCallbackType in_type,
    AkCallbackInfo in_info){
        isPlaying = false;
        Debug.Log("Audio Ended");

    }
    
}
