using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderMusic : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    private AudioSource[] audioSources;
    
    private void Start()
    {
        // Находим все AudioSource в сцене, включая выключенные
        audioSources = FindObjectsOfType<AudioSource>(true);

        // Установка начального значения слайдера равным сохраненному значению громкости
        volumeSlider.value = PlayerPrefs.GetFloat("GlobalVolume", 1f);

        // Установка начальной громкости каждого аудиоисточника
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volumeSlider.value;
        }

        // Добавление слушателя события изменения значения слайдера
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
    }

    public void UpdateListMusic()
    {
        // Находим все AudioSource в сцене
        audioSources = FindObjectsOfType<AudioSource>();
    }
    private void OnVolumeSliderValueChanged(float volume)
    {
        // Изменение громкости каждого аудиоисточника
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }

        // Сохранение значения громкости
        PlayerPrefs.SetFloat("GlobalVolume", volume);
    }
}
