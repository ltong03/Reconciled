using UnityEngine;

public class PlayerAudio :MonoBehaviour{
    public string wwiseEventName;
    public playerMovement playerMoveScript;
    public bool isFootstepPlaying = false;
    private float footstepTimer = 0f;
    public float footstepInterval = 0.75f;
    void Start(){
        playerMoveScript = GameObject.Find("Player").GetComponent<playerMovement>();

    }

    void Update(){
        footstepTimer += Time.deltaTime;
        if(footstepTimer >= footstepInterval && !isFootstepPlaying){
            PlayFootsteps();
            footstepTimer = 0f;
        }
    }
    
    void PlayFootsteps(){
        if(playerMoveScript.isMoving && !isFootstepPlaying){
            AkSoundEngine.PostEvent(wwiseEventName, 
            gameObject,
            (uint)AkCallbackType.AK_EndOfEvent,
            FootstepIsNotPlaying,
        null);
            isFootstepPlaying = true;
        }
    }
    void FootstepIsNotPlaying(object cookie, AkCallbackType type, AkCallbackInfo info){
        isFootstepPlaying = false;
    }
}
