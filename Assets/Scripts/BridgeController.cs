using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [Header("Bride animators")]
    [SerializeField] private Animator bridgeAnimator;

    [SerializeField] private Animator cameraAnimator;
    [SerializeField] private List<ParticleSystem> smokeParticles;

    void Start()
    {
        if (bridgeAnimator == null)
            bridgeAnimator = GetComponent<Animator>();

        if (bridgeAnimator != null)
        {
            bridgeAnimator.SetInteger("State", 0);
        }

        if (cameraAnimator != null)
        {
            cameraAnimator.SetInteger("ParkingState", 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            PlaySmokeAnimations();

            if (bridgeAnimator != null)
            {
                bridgeAnimator.SetInteger("State", 1);
            }

            if (cameraAnimator != null)
            {
                cameraAnimator.SetInteger("ParkingState", 1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            PlaySmokeAnimations();

            if (bridgeAnimator != null)
            {
                bridgeAnimator.SetInteger("State", 2);
                bridgeAnimator.speed = 1f;
            }

            if (cameraAnimator != null)
            {
                cameraAnimator.SetInteger("ParkingState", 2);
            }
        }
        StopAllCoroutines();
        StartCoroutine(SetIdleStates());
    }

    private IEnumerator SetIdleStates()
    {
        yield return new WaitForSeconds(8.0f);
        if (bridgeAnimator != null)
            bridgeAnimator.SetInteger("State", 0);

        if (cameraAnimator != null)
            cameraAnimator.SetInteger("ParkingState", 0);
    }

    private void PlaySmokeAnimations()
    {
        if (smokeParticles != null && smokeParticles.Count >= 0)
        {
            foreach (var particle in smokeParticles)
            {
                particle.Play();
            }
        }
    }
}