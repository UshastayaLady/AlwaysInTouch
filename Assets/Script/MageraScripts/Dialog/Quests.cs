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
            //        status.Message("Принесите склянку зомби");
            //        dialogueChanged = true;
            //        NPC.GetComponent<InstantiateDialogue>().changeDialogue();
            //    }


            //}
        }
    }

    public void AddQuest(string questText)
    {
        // Создаем новый экземпляр Text
        GameObject newText = Instantiate(questPrefab);

        // Устанавливаем родителем для нового текста Scroll View
        newText.transform.SetParent(scrollViewPrefab.transform, false);

        // Добавляем текст в новый объект Text
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
                break; // выход из цикла после удаления элемента
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
                questsPrefab = questsList.ToArray(); // преобразование List обратно в массив
                break; // выход из цикла после удаления элемента
            }
        }

        InstantiateDialogue.instance.changeDialogue();
    }

}