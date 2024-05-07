using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    public AudioSource audioSource;    

    void Start()
    {
        volumeSlider.value = GlobalVolumeManager.instance.globalVolume; // Установка начального значения слайдера
        audioSource.volume = GlobalVolumeManager.instance.globalVolume; // Установка начальной громкости аудио

        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeSliderValueChanged(); }); // Добавление слушателя события изменения значения слайдера
    }

    void OnVolumeSliderValueChanged()
    {
        float volume = volumeSlider.value;
        audioSource.volume = volume; // Изменение громкости аудио
        GlobalVolumeManager.instance.globalVolume = volume; // Сохранение глобальной громкости
    }
}
