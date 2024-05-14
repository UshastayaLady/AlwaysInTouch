using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private Text dialogueText;
    [SerializeField] private Text nameText;

    [SerializeField] private Animator boxAnim;
    [SerializeField] private Animator startAnim;

    //The queue of our dialogues
    private Queue<string> sentences;


    //Assigning a new queue
    private void Start()
    {
        sentences = new Queue<string>();
    }

    //Starting a dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);

        nameText.text = dialogue.name;
        sentences.Clear();

        //Sorting through all the drains from the array
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Making a consistent text
    IEnumerator TypeSentence(string sentences)
    {
        dialogueText.text = "";
        foreach (var letter in sentences.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    //Closing the dialog box
    public void EndDialogue()
    {
        boxAnim.SetBool("boxOpen", false);
    }
}
