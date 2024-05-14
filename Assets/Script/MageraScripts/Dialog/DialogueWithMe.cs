using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueWithMe : MonoBehaviour
{
    [SerializeField] private Animator startAnim;
    [SerializeField] private DialogueManager dm;

    private CursorMenager cursorMenager;

    public bool dialogueStart = false;

    private void Start()
    {
        cursorMenager = FindObjectOfType<CursorMenager>();
    }

    private void Update()
    {
        if (dialogueStart)
        {
            StartDealogueMe();
        }
        
    }

    private void StartDealogueMe()
    {
        startAnim.SetBool("startOpen", true);
        cursorMenager.cursorWork = true;
    }
   
}
