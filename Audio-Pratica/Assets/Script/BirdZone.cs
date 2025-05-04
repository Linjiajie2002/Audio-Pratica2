using System.Collections;
using UnityEngine;

public class BirdZone : MonoBehaviour
{

    public float minDelay = 1f;
    public float maxDelay = 20f;



    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;


    public float minVolume = 0.5f;
    public float maxVolume = 1f;

    private AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        StartCoroutine(PlayBirdSounds());
    }

    private IEnumerator PlayBirdSounds()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            int randomIndex = Random.Range(0, audioSources.Length);
            AudioSource selectedSource = audioSources[randomIndex];

            selectedSource.pitch = Random.Range(minPitch, maxPitch);
            selectedSource.volume = Random.Range(minVolume, maxVolume);


            float minimumPlayTime = 0.1f;
            if (!selectedSource.isPlaying ||
                selectedSource.time > selectedSource.clip.length - minimumPlayTime)
            {
                selectedSource.Play();
            }
        }
    }
}