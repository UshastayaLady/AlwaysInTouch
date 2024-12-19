using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTeleport : MonoBehaviour
{
    public GameObject Marker;
    public GameObject SignMove;
    //CursorManager cursorManager;

    private void Start() {
        Marker.SetActive(false);
    }

    public void ActivaTeteleport()
    {        
        Marker.SetActive(true);
        SignMove.SetActive(true);
    }

    //public void ButtonSkip()
    //{
    //    cursorManager.CloseCursor();
    //}
}
