using UnityEngine;

public class Trigger : MonoBehaviour
{
    private bool enter;
    private bool oneActiveInUpdate = false;
    [SerializeField] private bool cursor = false;
    [SerializeField] private bool button = false;
    [SerializeField] private bool onlyClose = false;
    [SerializeField] private bool onceOpenAndClose = false;    
    [SerializeField] private GameObject gameObjectOpen;
    
    private void Update()
    {
        if ((enter) && ((Input.GetKeyDown(KeyCode.Q) & button) || (!button & oneActiveInUpdate)))
        {
            gameObjectOpen.SetActive(!gameObjectOpen.activeSelf);
            oneActiveInUpdate = false;
        }

        if (gameObjectOpen.activeSelf & button)
        {
            PlayerManager.instance.PlayerFreezTrue();
            if (cursor)
                CursorManager.instance.cursorWork = true;
            if (Input.GetKeyDown(KeyCode.Q) & onlyClose)
            {
                PlayerManager.instance.PlayerFreezFalse();
                if (cursor)
                    CursorManager.instance.cursorWork = false;
                gameObjectOpen.SetActive(false);
                Destroy(this);
            }
        }
        else if (!gameObjectOpen.activeSelf & button)
        {
            PlayerManager.instance.PlayerFreezFalse();
            if (cursor)
                CursorManager.instance.cursorWork = false;
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {     
            enter = true;
            oneActiveInUpdate = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = false;
            if (!button)
                gameObjectOpen.SetActive(!gameObjectOpen.activeSelf);            
            if (onceOpenAndClose)
            {
                gameObjectOpen.SetActive(false);
                Destroy(this);
            }
        }
    }
        
}
