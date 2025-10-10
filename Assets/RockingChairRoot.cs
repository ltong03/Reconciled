using UnityEngine;

public class RockingChair : MonoBehaviour
{
    public float speed = 1f;
    public float angle = 10f;
    public bool isRocking = false;
    private float time;

    void Update()
    {
        if (isRocking)
        {
            time += Time.deltaTime * speed;
            float zRot = Mathf.Sin(time) * angle;
            transform.localRotation = Quaternion.Euler(zRot, 0, 0);
        }
    }

    public void StartRocking() => isRocking = true;
    public void StopRocking() => isRocking = false;
}
