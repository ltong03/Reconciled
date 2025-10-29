using UnityEngine;

public class Player_Footstep_Call : MonoBehaviour
{
 public void Player_footstep_call(string s)
    {
        AkSoundEngine.PostEvent(s, gameObject);
    }
}
