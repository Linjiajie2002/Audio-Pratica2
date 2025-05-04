using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AdvancedAudioController : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioMixerSnapshot indoorSnapshot;
    [SerializeField] AudioMixerSnapshot outdoorSnapshot;
    
    [Header("transition setting")]
    [SerializeField] float fadeDuration = 2f;
    [SerializeField] float transitionSpeed = 1f;

    private bool isOutdoor = false;
    private float currentLerp;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOutdoor = !isOutdoor;
            StopAllCoroutines();
            StartCoroutine(TransitionEnvironment());
        }
    }

    IEnumerator TransitionEnvironment()
    {
        float targetLerp = isOutdoor ? 1 : 0;
        
        while (Mathf.Abs(currentLerp - targetLerp) > 0.01f)
        {
            currentLerp = Mathf.MoveTowards(
                currentLerp, 
                targetLerp, 
                transitionSpeed * Time.deltaTime
            );

            // Snapshot transition
            audioMixer.TransitionToSnapshots(
                new[] { indoorSnapshot, outdoorSnapshot },
                new[] { 1 - currentLerp, currentLerp },
                fadeDuration
            );

            yield return null;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
    }
}