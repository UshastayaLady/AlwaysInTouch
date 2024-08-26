using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateDialogue : MonoBehaviour
{

    #region variables
    public static InstantiateDialogue instance = null;

    [SerializeField] private GameObject Window;
        
    [SerializeField] private Text nodeText;
    [SerializeField] private Text firstAnswer;
    [SerializeField] private Text secondAnswer;
    [SerializeField] private Text thirdAnswer;
    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button thirdButton;

    [HideInInspector] public bool dialogueEnded = false; //Закончен ли диалог?
    private bool firstNodeShown = false; //1 нод был показан?
        
    [HideInInspector]public TextAsset ta;

    private int currentNode = 0;    
    [HideInInspector] public int butClicked;
    Dialogue dialogue;
        
    [HideInInspector] public TaskBoardManager quest;

    #endregion

    void Start()
    {
        if (instance == null)
        { instance = this; }

        secondButton.enabled = false;
        thirdButton.enabled = false;
       
        firstButton.onClick.AddListener(but1);
        secondButton.onClick.AddListener(but2);
        thirdButton.onClick.AddListener(but3);
    }

    private void Update()
    {
        if (ta!=null)
        {
            if (dialogueEnded == false)
            {
                if (!firstNodeShown)
                {
                    firstStart();
                }

            }
        }
                   
    }

    #region // Buttons
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
    #endregion
        
    private void firstStart()
    {
        dialogue = null;       
        dialogue = Dialogue.Load(ta);       
        AnswerClicked(14);  //14 - для присвоения начальных значений в диалоге что бы не создавать новую функцию
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
            currentNode = dialogue.nodes[currentNode].answers[numberOfButton].nextNode;
        }
        
        nodeText.text = ""; //скидываем текст ответа каждый раз перед началом печати нового ответа НПС
        nodeText.text = dialogue.nodes[currentNode].Npctext;        

        firstAnswer.text = dialogue.nodes[currentNode].answers[0].text;     //первый ответ будет всегда            
        if (dialogue.nodes[currentNode].answers.Length >= 2)                //если ответов два
        {
            secondButton.enabled = true;
            secondAnswer.text = dialogue.nodes[currentNode].answers[1].text;    //показываем 
        }
        else
        {
            secondButton.enabled = false;                                       //иначе скрываем
            secondAnswer.text = "";
        }

        if (dialogue.nodes[currentNode].answers.Length == 3)
        {
            thirdButton.enabled = true;
            thirdAnswer.text = dialogue.nodes[currentNode].answers[2].text;
        }
        else
        {
            thirdButton.enabled = false;
            thirdAnswer.text = "";
        }

    }      

    public void checkingThings(int numberOfButton)
    {
        if (!DialogueManager.instance.dialogueClosed)
        {            

            if (dialogue.nodes[currentNode].answers[numberOfButton].quest != null)
                quest.AddTask(dialogue.nodes[currentNode].answers[numberOfButton].quest);                        

            if (dialogue.nodes[currentNode].answers[numberOfButton].questDone != null)
                //quest.RemoveQuest(list.dialObj[index].nodes[currentNode].answers[numberOfButton].questDone);

            if (dialogue.nodes[currentNode].answers[numberOfButton].after == "true")
            {                
                DialogueManager.instance.EndDialogue();
                StartCoroutine(waitFor(2f));
            }

            if (dialogue.nodes[currentNode].answers[numberOfButton].end == "true")
            {
                dialogueEnded = true;
                DialogueManager.instance.EndDialogue();
            }

        }
    }

    public IEnumerator waitFor(float time)
    {
        yield return new WaitForSeconds(time);     
    }  

    public void CloseDialogue()
    {

        if (dialogue != null)
        {            
            dialogue = null;
        }
        deleteDialogue();
        currentNode = 0; // Начинаем с первого узла
        firstNodeShown = false; // Сбрасываем флаг показа первого узла
        secondButton.enabled = false;
        thirdButton.enabled = false;
    }

    private void deleteDialogue()
    {
         
        nodeText.text = ""; 
        firstAnswer.text = "";
        secondAnswer.text = "";
        thirdAnswer.text = "";
    }    

}