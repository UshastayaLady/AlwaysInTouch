using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] audioSources;

    private void Start()
    {
        // ������� ��� AudioSource � �����
        audioSources = FindObjectsOfType<AudioSource>();

        // ��������� ��������� �� ������ ������������ ��������
        float volume = PlayerPrefs.GetFloat("GlobalVolume", 1f);
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }
}
