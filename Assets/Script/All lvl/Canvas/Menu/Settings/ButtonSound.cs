using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource Fx;
    [SerializeField] private AudioClip clip;
    public void ClicAudioClip()
    {
        Fx.PlayOneShot(clip);
    }

    public void StopAudioClip()
    {
        Fx.Stop(); // ������������� ��������������� ��������� �����
    }

    private void OnEnable()
    {
        ClicAudioClip(); // ������������� ���� ��� ��������� �������
    }

    private void OnDisable()
    {
        StopAudioClip(); // ������������� ���� ��� ���������� �������
    }
}
