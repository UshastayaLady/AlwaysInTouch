using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance = null;
    [SerializeField] private FirstPersonController FPS;
    [SerializeField] private bool freezStart = false;

    void Awake()
    {
        if (freezStart)
            PlayerFreezTrue();
    }

    private void Start()
    {
        if (instance == null)
        { instance = this; }
    }
    public void PlayerFreezTrue()
    {
        if (FPS.enabled == true)
            FPS.enabled = false;
    }
    public void PlayerFreezFalse()
    {
        if (FPS.enabled == false)
            FPS.enabled = true;
    }
}
