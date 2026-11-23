using System.Collections;
using UnityEngine;

public class ClampController : MonoBehaviour
{
    [Header("Clamp animators")]
    [SerializeField] private Animator clampAnimator;

    private Coroutine idleRoutine;
    void Start()
    {
        if (clampAnimator == null)
            clampAnimator = GetComponent<Animator>();

        if (clampAnimator != null)
            clampAnimator.SetInteger("State", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            if (clampAnimator != null)
            {
                clampAnimator.SetInteger("State", 1);
            }
        }

        if (idleRoutine != null)
        {
            StopCoroutine(idleRoutine);
            idleRoutine = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            if (clampAnimator != null)
            {
                clampAnimator.SetInteger("State", 2);
                clampAnimator.speed = 1f;
            }
        }
        if (idleRoutine != null) StopAllCoroutines();
        idleRoutine = StartCoroutine(SetIdleState());
    }

    private IEnumerator SetIdleState()
    {
        yield return new WaitForSeconds(8.0f);
        if (clampAnimator != null)
            clampAnimator.SetInteger("State", 0);

        idleRoutine = null;
    }
}
