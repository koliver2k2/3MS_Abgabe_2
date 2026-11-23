using UnityEngine;

public class ShipCollisionCheck : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[SHIPCOLLISIONCKECK] Stopping animation of {gameObject.name}");
        if (other != null && other.CompareTag("Player"))
        {
            if (animator != null)
                animator.speed = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            animator.SetInteger("State", 2);
        }
    }
}
