using UnityEngine;

public class FpsStartFreeze : MonoBehaviour
{
    private FirstPersonController FPS;
    void Awake()
    {
        FPS = FindObjectOfType<FirstPersonController>();
        FPS.setFreeze(true);
    }
}
