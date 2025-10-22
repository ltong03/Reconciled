using UnityEngine;

public class BodyAnimator : MonoBehaviour
{
    [SerializeField] private playerMovement movement;
    [SerializeField] private Animator animator;
    private void Update()
    {
        Vector3 velocity = movement.GetVelocity();
        float forwardSpeed = Vector3.Dot(velocity, transform.forward);
        float sideSpeed = Vector3.Dot(velocity, transform.right);

        animator.SetFloat("forwardSpeed", forwardSpeed);
        animator.SetFloat("sideSpeed", sideSpeed);
    }
}
