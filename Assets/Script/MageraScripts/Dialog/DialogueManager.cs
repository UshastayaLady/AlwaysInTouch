using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Animator boxAnim;
    [SerializeField] private Animator startAnim;

    public static DialogueManager instance = null;
    public void Start()
    {
        if (instance == null)
        { instance = this; }

    }        

    //Starting a dialogue
    public void StartDialogue()
    {
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);
        InicializateMonologue.instance.startScene();
    }    

    //Closing the dialog box
   public void EndDialogue()
    {
        boxAnim.SetBool("boxOpen", false);
    }
}
