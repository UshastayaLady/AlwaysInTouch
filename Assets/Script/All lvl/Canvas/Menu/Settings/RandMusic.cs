using UnityEngine;

public class RandMusic : MonoBehaviour
{
    

    public AudioClip[] clips; // массив аудиодорожек
    public AudioSource audioSourse; // хвукопроизводитель

    //Рандомайзер для музыки
    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    void Update()

    {
        if (!audioSourse.isPlaying)
        {
            audioSourse.clip = GetRandomClip();
            audioSourse.Play(); 
        }
    }
    
}
