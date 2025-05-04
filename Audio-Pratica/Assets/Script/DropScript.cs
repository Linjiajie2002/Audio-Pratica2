using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class DropScript : MonoBehaviour
{
    public float fallSpeedThreshold = 3f; 

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
        
        if (rb.velocity.y < -fallSpeedThreshold)
        {
            wasFalling = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (wasFalling)
        {
            audioSource.Play();
            wasFalling = false; 
        }
    }
}
