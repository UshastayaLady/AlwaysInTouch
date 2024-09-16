using UnityEngine;

public class Trigger : MonoBehaviour
{
    private bool enter;
    private bool oneActiveInUpdate = false;
    [SerializeField] private bool button = false;
    [SerializeField] private bool close = false;
    [SerializeField] private bool once = false;
    [SerializeField] private bool many = false;
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
            if (Input.GetKeyDown(KeyCode.Q) & close)
            {
                PlayerManager.instance.PlayerFreezFalse();
                gameObjectOpen.SetActive(false);                
                Destroy(this);
            }
        }
        else if (!gameObjectOpen.activeSelf & button)
        {
            PlayerManager.instance.PlayerFreezFalse();
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
            if (once)
            {
                gameObjectOpen.SetActive(false);
                Destroy(this);
            }
        }
    }
        
}
