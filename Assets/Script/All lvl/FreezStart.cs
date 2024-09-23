using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezStart : MonoBehaviour
{
    private FirstPersonController FPS;
    private void Start()
    {
        FPS = FindObjectOfType<FirstPersonController>();
        FPS.setFreeze(true);
    }

    // Update is called once per frame
    public void StopFreezButton()
    {
        FPS.setFreeze(false);
    }
}
