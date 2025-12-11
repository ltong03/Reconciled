using UnityEngine;
using TMPro;
public class updateText : MonoBehaviour
{
    [SerializeField] private TextMeshPro skyText;
    private string parentName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skyText.text = "???";
        parentName = transform.parent.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            skyText.text = parentName;
        }
    }
}
