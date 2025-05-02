using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class DropScript : MonoBehaviour
{
    public float fallSpeedThreshold = 3f; // �ٶ���ֵ��ֻ�е������ٶȳ������ֵ�Ų�������

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
        // ��¼�Ƿ����ڿ�������
        if (rb.velocity.y < -fallSpeedThreshold)
        {
            wasFalling = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���֮ǰ��������״̬��������ײ�˵������������
        if (wasFalling)
        {
            audioSource.Play();
            wasFalling = false; // ����״̬�������δ���
        }
    }
}
