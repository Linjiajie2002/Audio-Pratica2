using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animation anim;
    private bool isOpen = false;
    public AudioSource audioOpenSource;
    public AudioSource audioCloseSource;


    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
                anim.Play("DoorClose"); 
            else
                anim.Play("DoorOpen");   

            isOpen = !isOpen;
        }
    }

    public void PlayDoorSound()
    {
        if (isOpen)
        {
            if (audioCloseSource && !audioCloseSource.isPlaying)
                audioCloseSource.Play();
        }
        else
        {
            if (audioOpenSource && !audioOpenSource.isPlaying)
                audioOpenSource.Play();
        }

    }
}
