using UnityEngine;

public class PlayerDestroyOnEnterPOI : MonoBehaviour
{
    public string specificObjectTag = "Body";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(specificObjectTag))
        {
            Destroy(GetComponent<Collider>());
        }
    }
}
