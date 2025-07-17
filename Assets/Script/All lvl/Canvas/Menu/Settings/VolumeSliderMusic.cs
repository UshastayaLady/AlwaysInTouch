using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderMusic : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    private AudioSource[] audioSources;
    
    private void Start()
    {
        // ������� ��� AudioSource � �����, ������� �����������
        audioSources = FindObjectsOfType<AudioSource>(true);

        // ��������� ���������� �������� �������� ������ ������������ �������� ���������
        volumeSlider.value = PlayerPrefs.GetFloat("GlobalVolume", 1f);

        // ��������� ��������� ��������� ������� ��������������
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volumeSlider.value;
        }

        // ���������� ��������� ������� ��������� �������� ��������
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
    }

    public void UpdateListMusic()
    {
        // ������� ��� AudioSource � �����
        audioSources = FindObjectsOfType<AudioSource>();
    }
    private void OnVolumeSliderValueChanged(float volume)
    {
        // ��������� ��������� ������� ��������������
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }

        // ���������� �������� ���������
        PlayerPrefs.SetFloat("GlobalVolume", volume);
    }
}
