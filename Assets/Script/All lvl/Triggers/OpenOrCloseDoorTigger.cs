using UnityEngine;

public class OpenOrCloseDoorTigger : MonoBehaviour
{
    [SerializeField] private string blockDoorQuest;
    [SerializeField] private string nextDoorQuest;
    [SerializeField] private bool srazuBlock=false;
    [SerializeField] private bool srazuOpen = false;
    [SerializeField] private GameObject blockOpenDoor;
    [SerializeField] private GameObject nextOpenDoor;

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (blockDoorQuest != null & TaskBoardManager.instance.FindTaskFromBoard(blockDoorQuest) & blockOpenDoor != null)
               Close();
            
            if (nextDoorQuest != null & TaskBoardManager.instance.FindTaskFromBoard(nextDoorQuest) & nextOpenDoor != null)
                nextOpenDoor.GetComponent<BoxCollider>().enabled = true;
                        
                if (blockOpenDoor != null & srazuBlock)
                    Close();

                if (nextOpenDoor != null & srazuOpen)
                    nextOpenDoor.GetComponent<BoxCollider>().enabled = true;                    
        }       
    }
    private void Close()
    {       
        OpenDoor script = blockOpenDoor.GetComponent<OpenDoor>();
        script.IsCloseDoor();
        blockOpenDoor.GetComponent<BoxCollider>().enabled = false;
    }
}
