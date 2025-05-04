using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip woodSound;
    public AudioClip stoneSound;
    public AudioClip grassSound;

    public float footstepInterval = 0.5f;  // 脚步声播放间隔
    private float footstepTimer = 0f;

    public Rigidbody rb; // 角色刚体

    void Update()
    {
        footstepTimer += Time.deltaTime;

        // 判断是否移动 + 是否在地面
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
        // 发射一条往下的射线，检测脚下是否是地面
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
