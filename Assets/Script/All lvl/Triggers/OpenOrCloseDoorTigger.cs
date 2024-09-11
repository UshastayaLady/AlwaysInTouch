using UnityEngine;

public class OpenOrCloseDoorTigger : MonoBehaviour
{
    [SerializeField] private string blockDoorQuest;
    [SerializeField] private string nextDoorQuest;
    [SerializeField] private bool srazuBlock=false;
    [SerializeField] private bool srazuOpen = false;
    [SerializeField] private bool srazuDeleteScript = false;
    [SerializeField] private bool srazuDeleteObject = false;
    [SerializeField] private int elements = 1;
    private int count = 0;
    [SerializeField] private GameObject blockOpenDoor;
    [SerializeField] private GameObject nextOpenDoor;

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (blockDoorQuest != null & TaskBoardManager.instance.FindTaskFromBoard(blockDoorQuest) & blockOpenDoor != null)
            {
                Close();
                blockDoorQuest = null;
            }
              

            if (nextDoorQuest != null & TaskBoardManager.instance.FindTaskFromBoard(nextDoorQuest) & nextOpenDoor != null)
            { 
                nextOpenDoor.GetComponent<BoxCollider>().enabled = true;
                nextDoorQuest = null;
                count += 1;
            }

            if (blockOpenDoor != null & srazuBlock)
            {
                Close();
                srazuBlock = false;
            }
                    

            if (nextOpenDoor != null & srazuOpen)
            {
                nextOpenDoor.GetComponent<BoxCollider>().enabled = true;
                srazuOpen = false;
                count += 1;
            }                                      
        }
        if (count == elements)
        {
            DelScript();
        }
    }
    private void Close()
    {       
        OpenDoor script = blockOpenDoor.GetComponent<OpenDoor>();
        script.IsCloseDoor();
        blockOpenDoor.GetComponent<BoxCollider>().enabled = false;
        count += 1;
    }

    private void DelScript()
    {
        if (srazuDeleteScript)
        {
            Destroy(this);
        }
        if (srazuDeleteObject)
        {
            Destroy(gameObject);
        }
    }
}
