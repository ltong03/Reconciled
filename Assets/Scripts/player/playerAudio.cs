using UnityEngine;
// I'm thinking put all the player moans, grunts, footsteps, etc here 
public class PlayerAudio :MonoBehaviour{
    //wwiseEventName is the event name found in the wwise project
    public string wwiseEventName;
    //reference playerMovement so that I can access playerMovement data fields 
    public playerMovement playerMoveScript;
    public bool isFootstepPlaying = false;
    //footstepTimer will be constantly counting up in each frame
    private float footstepTimer = 0f;
    // once footstepTimer is above footstepInterval, we allow the footstep sound effect to play
    public float footstepInterval = 0.75f;
    // assigning playerMoveScript to Player's playerMovement class
    void Start(){
        playerMoveScript = GameObject.Find("Player").GetComponent<playerMovement>();

    }
    //Set up a timer to set an interval between steps 
    void Update(){
        footstepTimer += Time.deltaTime;
        if(footstepTimer >= footstepInterval && !isFootstepPlaying){
            PlayFootsteps();
            footstepTimer = 0f;
        }
    }
    // Calls Wwise function to play audio if player is moving & footsteps are not playing. This makes sure footstep sound effects are not overlapping
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
    //This method is called when audio is done playing. It sets the isFootstepPlaying to false, so that more footstep audio can be played after it's done.  
    void FootstepIsNotPlaying(object cookie, AkCallbackType type, AkCallbackInfo info){
        isFootstepPlaying = false;
    }
}
