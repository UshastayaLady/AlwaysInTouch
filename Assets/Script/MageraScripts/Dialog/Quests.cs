using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public Inventory inventory;
    public StatusScript status;
    [SerializeField]
    public string objectName = "";
    [SerializeField]
    public string type = "";
    public bool questActive = false;
    [SerializeField]
    public GameObject NPC;
    bool dialogueChanged = false;

    public void Start()
    {
    }

    public void Update()
    {
        if (questActive)
        {
            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] != null)
                {
                    if (inventory.items[i].name == objectName + type)
                    {
                        if (dialogueChanged == false)
                        {
                            status.Message("Принесите склянку зомби");
                            dialogueChanged = true;
                            NPC.GetComponent<InstantiateDialogue>().changeDialogue();
                        }

                    }
                }
            }
        }
    }

    public void Ques(string quest, GameObject npc)
    {
        if (npc.name == "DennisZ")
        {
            if (quest == "find")
            {
                status.Message("Найдите склянку с жидкостью и принесите зомби");
                objectName = npc.name;
                type = quest;
                NPC = npc;
                questActive = true;
            }
        }
    }

    public void awardForQuest(string quest)
    {
        if (quest == "find")
        {
            int exp = 30;
            status.Message("Вы получили !" + exp + "! опыта за выполнение задания");
        }
    }

    public IEnumerator replaceNPC(GameObject oldNPC, GameObject newNPC)
    {
        oldNPC.GetComponent<InstantiateDialogue>().dialogueEnded = true;
        yield return new WaitForSeconds(1f);
        Instantiate(newNPC, new Vector3(oldNPC.transform.position.x, oldNPC.transform.position.y, oldNPC.transform.position.z), Quaternion.identity);
        oldNPC.GetComponent<InstantiateDialogue>().Window.SetActive(true);
        newNPC.GetComponent<InstantiateDialogue>().Window = oldNPC.GetComponent<InstantiateDialogue>().Window;
        oldNPC.GetComponent<InstantiateDialogue>().Window.SetActive(false);
        oldNPC.SetActive(false);
    }

    public void motions(string motion, GameObject oldNPC, GameObject newNPC)
    {
        if (motion == "replaceNPC")
        {
            StartCoroutine(replaceNPC(oldNPC, newNPC));
        }
    }
}