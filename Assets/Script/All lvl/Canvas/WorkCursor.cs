using UnityEngine;

public class WorkCursor : CursorManager
{

    void OnEnable()
    {
        OpenCursor();
    }

    void OnDisable()
    {
        CloseCursor();
    }
}