using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private int countCursorsOpen = 0;

    private void Start()
    {        
        Cursor.visible = true;
    }

    protected void OpenCursor()
    {
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
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }       
}
