using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private FirstPersonController fps;
    private static int countCursorsOpen = 0;

    private void Awake()
    {
        fps = FindObjectOfType<FirstPersonController>();
    }

    private void Start()
    {        
        Cursor.visible = true;
    }

    protected void OpenCursor()
    {
        if (fps != null)
            fps.enabled = false;
        countCursorsOpen++;
        Debug.Log(countCursorsOpen);
        if (countCursorsOpen == 1)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    protected void CloseCursor()
    {
        if (countCursorsOpen > 0)
        {
            countCursorsOpen--;
            if (countCursorsOpen == 0)
            {
                if (fps != null)
                    fps.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }       
}
