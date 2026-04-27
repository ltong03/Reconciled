using UnityEngine;

public class AKRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC MyRTPC;

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MyRTPC.SetGlobalValue(100);
        }
    }
}
