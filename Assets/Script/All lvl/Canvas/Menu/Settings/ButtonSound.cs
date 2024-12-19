using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource Fx;
    public AudioClip hoverClip;
    public AudioClip ClicClip;
    // Start is called before the first frame update

    public void HoverAudioClip()
    {
        Fx.PlayOneShot(hoverClip);
    }
    public void ClicAudioClip()
    {
        Fx.PlayOneShot(ClicClip);
    }
}
