using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public string postEvent;

    public void OnPointerEnter(PointerEventData enterData){
        AkSoundEngine.PostEvent(postEvent, gameObject);
        Debug.Log("Mouse in on Button");
    }
    public void OnPointerExit(PointerEventData exitData){

    }
    
}
