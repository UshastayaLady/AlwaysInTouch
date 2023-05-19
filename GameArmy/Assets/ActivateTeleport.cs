using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTeleport : MonoBehaviour
{
    public GameObject Marker;
    public GameObject SignMove;

    private void Start() {
        Marker.SetActive(false);
    }

    public void ActivaTeteleport(){

        FirstPersonController FPS = FindObjectOfType<FirstPersonController>();
        FPS.setFreeze(true);
        Marker.SetActive(true);
        SignMove.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void ButtonSkip()
    {
        FirstPersonController FPS = FindObjectOfType<FirstPersonController>();
        FPS.setFreeze(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
