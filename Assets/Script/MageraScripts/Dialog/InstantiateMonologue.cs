using UnityEngine;
using UnityEngine.UI;

public class InstantiateMonologue : MonoBehaviour
{
    public static InstantiateMonologue instance = null;

    public TextAsset[] assets;
    private int currentAsset;
    private int currentNode;

    private Monologue monologue;

    private bool firstStart = true;

    
    
    [SerializeField] private Text IntroText;
    [SerializeField] private Image IntroPersona;
    [SerializeField] private Text IntroPersonaName;
    [SerializeField] private Button IntroButton;

   
    public void Start()
    {
        if (instance == null)
        { instance = this; }

        currentAsset = 0;
        currentNode = 0;       

    }    

    public void LoadAsset()
    {
        currentNode = 0;
        monologue = null;
        monologue = Monologue.Load(assets[currentAsset]);
    }

    public void startScene()
    {
       
        if (firstStart)
        {
            IntroButton.onClick.AddListener(NextIntroNode);            
            firstStart = false;
        }
        
        LoadAsset();
        NextIntroNode();
        
    }


    public void NextIntroNode()
    {
        if (currentNode == monologue.nodes.Length)
        {
            DialogueManager.instance.EndDialogue();
        }
        else 
        {
            IntroText.text = "";
            StartCoroutine(PrintMachineEffect.instance.printMachineEffect(IntroText, monologue.nodes[currentNode].Npctext, IntroButton));
            currentNode++;
        }
        
    }
}
