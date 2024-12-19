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
        volumeSlider.value = PlayerPrefs.GetFloat("GlobalVolume", 1f); // Установка начального значения слайдера равным сохраненному значению громкости

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volumeSlider.value; // Установка начальной громкости каждого аудиоисточника на основе значения слайдера
        }

        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeSliderValueChanged(); }); // Добавление слушателя события изменения значения слайдера
    }

    public void OnVolumeSliderValueChanged()
    {
        float volume = volumeSlider.value;

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume; // Изменение громкости каждого аудиоисточника
        }

        PlayerPrefs.SetFloat("GlobalVolume", volume); // Сохранение значения громкости
    }
}
