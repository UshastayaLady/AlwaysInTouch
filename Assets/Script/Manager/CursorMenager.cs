using UnityEngine;

public class CursorMenager : MonoBehaviour
{
    [SerializeField] private Texture2D customCursor; // Переменная для хранения текстуры курсора
    [SerializeField] private Vector2 hotSpot = new Vector2(0, 0); // Точка привязки курсора (можно настроить)

    public static CursorMenager instance = null;
    public bool cursorWork = true;

    public void Start()
    {
        if (instance == null)
        { instance = this; }
        if(customCursor!=null)       
            Cursor.SetCursor(customCursor, hotSpot, CursorMode.Auto); // Установка кастомного курсора
    }
   
    void Update()
    {
        if (cursorWork)
        { 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ClikButtonFalse()
    {
        cursorWork = false;
    }
}
