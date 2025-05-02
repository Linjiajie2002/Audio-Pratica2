using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class DropScript : MonoBehaviour
{
    public float fallSpeedThreshold = 3f; // 速度阈值：只有当掉落速度超过这个值才播放声音

    private Rigidbody rb;
    private AudioSource audioSource;

    private bool wasFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 记录是否正在快速下落
        if (rb.velocity.y < -fallSpeedThreshold)
        {
            wasFalling = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 如果之前处于下落状态，并且碰撞了地面或其他物体
        if (wasFalling)
        {
            audioSource.Play();
            wasFalling = false; // 重置状态，避免多次触发
        }
    }
}
