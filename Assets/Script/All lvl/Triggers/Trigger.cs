using UnityEngine;

public class Trigger : MonoBehaviour
{
    private bool enter;
    private bool oneActiveInUpdate = false;
    [SerializeField] private bool noButton = false;
    [SerializeField] private bool once = false;
    [SerializeField] private bool many = false;
    [SerializeField] private GameObject gameObjectOpen;


    private void Update()
    {
        if ((enter) && ((Input.GetKeyDown(KeyCode.Q) & !noButton) || (noButton & oneActiveInUpdate)))
        {
            if (many)
                gameObjectOpen.SetActive(!gameObjectOpen.activeSelf);

            if (once)
            {
                gameObjectOpen.SetActive(true);
                Destroy(this);
            }
            oneActiveInUpdate = false;
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
            if (noButton)
                gameObjectOpen.SetActive(!gameObjectOpen.activeSelf);
        }
    }
        
}
