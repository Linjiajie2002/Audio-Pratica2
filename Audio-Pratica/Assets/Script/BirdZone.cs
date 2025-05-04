using System.Collections;
using UnityEngine;

public class BirdZone : MonoBehaviour
{
    [Header("播放时间间隔")]
    public float minDelay = 1f;
    public float maxDelay = 20f;

    [Header("音调设置")]
    [Tooltip("建议范围 0.8-1.2 保持自然")]
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    [Header("音量设置")]
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

            // 设置随机参数
            selectedSource.pitch = Random.Range(minPitch, maxPitch);
            selectedSource.volume = Random.Range(minVolume, maxVolume);

            // 如果音效长度过短，增加延迟保护
            float minimumPlayTime = 0.1f;
            if (!selectedSource.isPlaying ||
                selectedSource.time > selectedSource.clip.length - minimumPlayTime)
            {
                selectedSource.Play();
            }
        }
    }
}