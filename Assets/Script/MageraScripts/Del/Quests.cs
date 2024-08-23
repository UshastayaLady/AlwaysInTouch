using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Quests : MonoBehaviour
{
    public static Quests instance = null;

    //public Inventory inventory;
    //public StatusScript status;
    [SerializeField]
    public string objectName = "";
    [SerializeField]
    public string type = "";
    public bool questActive = false;
    [SerializeField]
    public GameObject NPC;
    bool dialogueChanged = false;

        
    //public Text questStatus;
    public GameObject questPrefab;
    public GameObject scrollViewPrefab;

    public GameObject [] questsPrefab;

    public void Start()
    {
        if (instance == null)
        { instance = this; }
    }
       

    public void Update()
    {
        if (questActive)
        {                        

            //for (int i = 0; i < questsPrefab.Length; i++)
            //{

            //    if (dialogueChanged == false)
            //    {
            //        status.Message("��������� ������� �����");
            //        dialogueChanged = true;
            //        NPC.GetComponent<InstantiateDialogue>().changeDialogue();
            //    }


            //}
        }
    }

    public void AddQuest(string questText)
    {
        // ������� ����� ��������� Text
        GameObject newText = Instantiate(questPrefab);

        // ������������� ��������� ��� ������ ������ Scroll View
        newText.transform.SetParent(scrollViewPrefab.transform, false);

        // ��������� ����� � ����� ������ Text
        newText.GetComponent<Text>().text = questText;

        questsPrefab.Append(newText);

        InstantiateDialogue.instance.changeDialogue();

    }

    public void MakeQuest(string make)
    {
        for (int i = 0; i < questsPrefab.Length; i++)
        {
            if (questsPrefab[i].GetComponent<Text>().text == make)
            {                
                questsPrefab[i].GetComponent<Text>().text = "<del>" + questsPrefab[i].GetComponent<Text>().text + "</del>";
                break; // ����� �� ����� ����� �������� ��������
            }
        }
    }

    public void RemoveQuest(string delete)
    {
       
        List<GameObject> questsList = new List<GameObject>(questsPrefab);

        for (int i = 0; i < questsList.Count; i++)
        {
            if (questsList[i].GetComponent<Text>().text == delete)
            {
                questsList.RemoveAt(i);
                questsPrefab = questsList.ToArray(); // �������������� List ������� � ������
                break; // ����� �� ����� ����� �������� ��������
            }
        }

        InstantiateDialogue.instance.changeDialogue();
    }

}