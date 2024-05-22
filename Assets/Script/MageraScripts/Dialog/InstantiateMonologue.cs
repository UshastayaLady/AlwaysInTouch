using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


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

    public IEnumerator printEffect(float time)
    {
        IntroButton.enabled = false;
        for (int i = 0; i < monologue.nodes[currentNode].Npctext.Length; i++)
        {
            IntroText.text += monologue.nodes[currentNode].Npctext[i];
            yield return new WaitForSeconds(time);
        }
        IntroButton.enabled = true;
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
            StartCoroutine(printEffect(0.01f));
            currentNode++;
        }
        
    }
}
