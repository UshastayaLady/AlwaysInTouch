using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkCursor : NewCursorManager
{
    private FirstPersonController player;
    private void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.GetComponent<FirstPersonController>();
        }
    }

    void OnEnable()
    {
        if (player != null) 
            player.enabled = false;
        OpenCursor();
    }

    void OnDisable()
    {
        if (player != null)
            CloseCursor();
        player.enabled = true;
    }
}