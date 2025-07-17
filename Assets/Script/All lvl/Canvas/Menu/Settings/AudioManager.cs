using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] audioSources;

    private void Start()
    {
        // Находим все AudioSource в сцене
        audioSources = FindObjectsOfType<AudioSource>();

        // Установка громкости на основе сохраненного значения
        float volume = PlayerPrefs.GetFloat("GlobalVolume", 1f);
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }
}
