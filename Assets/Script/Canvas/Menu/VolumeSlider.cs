using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource[] audioSources;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("GlobalVolume", 1f); // ��������� ���������� �������� �������� ������ ������������ �������� ���������

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volumeSlider.value; // ��������� ��������� ��������� ������� �������������� �� ������ �������� ��������
        }

        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeSliderValueChanged(); }); // ���������� ��������� ������� ��������� �������� ��������
    }

    public void OnVolumeSliderValueChanged()
    {
        float volume = volumeSlider.value;

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume; // ��������� ��������� ������� ��������������
        }

        PlayerPrefs.SetFloat("GlobalVolume", volume); // ���������� �������� ���������
    }




}
