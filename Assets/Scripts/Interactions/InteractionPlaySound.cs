using UnityEngine;

public class InteractionPlaySound:Interactable{
    public string wwiseEventName = "amb_bed";
    private bool isPlayerNearby = false;
    public override void Interact(){
        PlaySong();
        Debug.Log("Play Sound");
    }
    void PlaySong(){
        AkSoundEngine.PostEvent(wwiseEventName, gameObject);
    }
    
}
