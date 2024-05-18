using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMenager : MonoBehaviour
{
    public static CursorMenager instance = null;

    public void Start()
    {
        if (instance == null)
        { instance = this; }
    }
    public bool cursorWork=true;

    void Update()
    {
        if (cursorWork)
        { 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
