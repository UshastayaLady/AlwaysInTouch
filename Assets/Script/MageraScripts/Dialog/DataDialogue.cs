using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDialogue : MonoBehaviour
{
    public string characterName;
    public string[] dialogueSentences;

    public Dialogue GetDialogue()
    {
        Dialogue dialogue = new Dialogue();
        dialogue.name = characterName;
        dialogue.sentences = dialogueSentences;
        return dialogue;
    }
}
