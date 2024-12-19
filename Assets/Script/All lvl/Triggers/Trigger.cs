using UnityEngine;

public class Trigger : MonoBehaviour
{
    
    private bool enter;
    private bool oneActiveInUpdate = false;
    private bool buttonClickOne = false;
    [SerializeField] private bool button = false;
    [SerializeField] private bool onlyClose = false;
    [SerializeField] private bool onceOpenAndClose = false;    
    [SerializeField] private GameObject gameObjectOpen;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    private void Update() 
    {
        if ((enter) && ((Input.GetKeyDown(interactKey) & button) || (!button & oneActiveInUpdate)))
        {            
            gameObjectOpen.SetActive(!gameObjectOpen.activeSelf);
            buttonClickOne = true;
            oneActiveInUpdate = false;
        }

        if (gameObjectOpen.activeSelf & button)
        {
            if (Input.GetKeyDown(interactKey) & onlyClose)
            {
                gameObjectOpen.SetActive(false);
                Destroy(this);
            }
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
            if (onceOpenAndClose & (buttonClickOne || !button))
            {
                gameObjectOpen.SetActive(false);
                Destroy(this);
            }
        }
    }
        
}
