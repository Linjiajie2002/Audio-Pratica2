using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip woodSound;
    public AudioClip stoneSound;
    public AudioClip grassSound;

    public float footstepInterval = 0.5f;  // �Ų������ż��
    private float footstepTimer = 0f;

    public Rigidbody rb; // ��ɫ����

    void Update()
    {
        footstepTimer += Time.deltaTime;

        // �ж��Ƿ��ƶ� + �Ƿ��ڵ���
        if (IsGrounded() && rb.velocity.magnitude > 0.2f)
        {
            if (footstepTimer >= footstepInterval)
            {
                PlayFootstepSound();
                footstepTimer = 0f;
            }
        }
    }

    bool IsGrounded()
    {
        // ����һ�����µ����ߣ��������Ƿ��ǵ���
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void PlayFootstepSound()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            string tag = hit.collider.tag;
            switch (tag)
            {
                case "wood":
                    audioSource.PlayOneShot(woodSound);
                    break;
                case "rock":
                    audioSource.PlayOneShot(stoneSound);
                    break;
                case "Grass":
                    audioSource.PlayOneShot(grassSound);
                    break;
            }
        }
    }
}
