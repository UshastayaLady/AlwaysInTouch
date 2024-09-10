using UnityEngine;

public class Trigger : MonoBehaviour
{
    private bool enter;
    [SerializeField] private bool once = false;
    [SerializeField] private bool many = false;
    [SerializeField] private GameObject gameObjectOpen;


    private void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.Q))
        {
            if (many)
                gameObjectOpen.SetActive(!gameObjectOpen.activeSelf);

            if(once)
            {
                gameObjectOpen.SetActive(true);
                Destroy(this);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {     
            enter = true;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = false;
        }
    }
}
