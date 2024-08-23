using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateDialogue : MonoBehaviour
{
    public static InstantiateDialogue instance = null;

    public GameObject Window;
    public Sprite Avatar;
        
    public Text nodeText;
    public Text firstAnswer;    
    public Text secondAnswer;    
    public Text thirdAnswer;    
    public Button firstButton;    
    public Button secondButton;    
    public Button thirdButton;

    public bool dialogueEnded = false;

    
    public TextAsset[] ta;
    public int currentTa = 0;

    private bool firstNodeShown = false;

    public int currentNode = 0;
    [HideInInspector]
    public int butClicked;
    Dialogue dialogue;
    DialogueObjects list;
    public static int index;
    public string Quest = "";
    public Quests quest;
    public GameObject replaceNPC;

    public string questText;

    void Start()
    {
        if (instance == null)
        { instance = this; }

        secondButton.enabled = false;
        thirdButton.enabled = false;
       
        list = FindObjectOfType<DialogueObjects>();

        firstButton.onClick.AddListener(but1);
        secondButton.onClick.AddListener(but2);
        thirdButton.onClick.AddListener(but3);

    }

    private void Update()
    {


        if (DialogueManager.instance.dialogueClosed == false)
        {            
            
            if (!firstNodeShown)
            {
                firstStart();
            }

        }
        else
        {
            
            if (dialogue != null)
            {
                dialogue.Remove();            
            }
            deleteDialogue();
            firstNodeShown = false;
        }          
    }

    private void but1()
    {
        butClicked = 0;
        AnswerClicked(0);
    }
    private void but2()
    {
        butClicked = 1;
        AnswerClicked(1);
    }
    private void but3()
    {
        butClicked = 2;
        AnswerClicked(2);
    }

    private void firstStart()
    {
        dialogue = null;
        dialogue = Dialogue.Load(ta[currentTa]);
        list.AddDialogue(dialogue);
        index = --list.index;
        AnswerClicked(14);  //14 - ��� ���������� ��������� �������� � ������� ��� �� �� ��������� ����� �������
    }

    private void deleteDialogue()
    {
         
        nodeText.text = ""; 
        firstAnswer.text = "";
        secondAnswer.text = "";
        thirdAnswer.text = "";
    }


    public void AnswerClicked(int numberOfButton)
    {

        if (numberOfButton == 14)
        {
            if (!firstNodeShown)
            {
                currentNode = 0;
                firstNodeShown = true;
            }
        }
        else
        {
            checkingThings(numberOfButton);

            currentNode = list.dialObj[index].nodes[currentNode].answers[numberOfButton].nextNode;
        }
        
        nodeText.text = ""; //��������� ����� ������ ������ ��� ����� ������� ������ ������ ������ ���
        nodeText.text = list.dialObj[index].nodes[currentNode].Npctext;        

        firstAnswer.text = list.dialObj[index].nodes[currentNode].answers[0].text;     //������ ����� ����� ������            
        if (list.dialObj[index].nodes[currentNode].answers.Length >= 2)                //���� ������� ���
        {
            secondButton.enabled = true;
            secondAnswer.text = list.dialObj[index].nodes[currentNode].answers[1].text;    //���������� 
        }
        else
        {
            secondButton.enabled = false;                                       //����� ��������
            secondAnswer.text = "";
        }

        if (list.dialObj[index].nodes[currentNode].answers.Length == 3)
        {
            thirdButton.enabled = true;
            thirdAnswer.text = list.dialObj[index].nodes[currentNode].answers[2].text;
        }
        else
        {
            thirdButton.enabled = false;
            thirdAnswer.text = "";
        }

    }    

    public IEnumerator waitFor(float time)
    {
        yield return new WaitForSeconds(time);
        dialogueEnded = false;
    }

    public void checkingThings(int numberOfButton)
    {
        if (!DialogueManager.instance.dialogueClosed)
        {
            if (list.dialObj[index].nodes[currentNode].answers[numberOfButton].end == "true")
            { 
                dialogueEnded = true;
                DialogueManager.instance.EndDialogue();
            }

            if (list.dialObj[index].nodes[currentNode].answers[numberOfButton].quest != null)
                quest.AddQuest(list.dialObj[index].nodes[currentNode].answers[numberOfButton].quest);            

            if (list.dialObj[index].nodes[currentNode].answers[numberOfButton].questDone != null)
                quest.RemoveQuest(list.dialObj[index].nodes[currentNode].answers[numberOfButton].questDone);

            if (list.dialObj[index].nodes[currentNode].answers[numberOfButton].after == "true")
            {
                dialogueEnded = true;
                DialogueManager.instance.EndDialogue();
                StartCoroutine(waitFor(2f));
            }
            
        }
    }



    public void changeDialogue()
    {
        currentTa++;
        dialogueEnded = false;
    }

}