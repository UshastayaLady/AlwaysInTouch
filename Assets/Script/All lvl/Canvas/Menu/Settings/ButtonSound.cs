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
        Fx.Stop(); // Останавливаем воспроизведение звукового клипа
    }

    private void OnEnable()
    {
        ClicAudioClip(); // Воспроизводим звук при включении объекта
    }

    private void OnDisable()
    {
        StopAudioClip(); // Останавливаем звук при выключении объекта
    }
}
