using UnityEngine;

public class NewCursorManager : MonoBehaviour
{
    private int countCursorsOpen = 0;
    [SerializeField] private Texture2D cursorTexture; 
    private Vector2 hotspot = new Vector2(0, 0);

    private void Start()
    {        
        //Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
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
                Cursor.SetCursor(null, hotspot, CursorMode.Auto);
            }
        }
    }

    protected void ChangCursor(bool yes, Texture2D cursorNewTexture)
    {
        if (yes)
            Cursor.SetCursor(cursorNewTexture, hotspot, CursorMode.Auto);
        else
            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }
}
