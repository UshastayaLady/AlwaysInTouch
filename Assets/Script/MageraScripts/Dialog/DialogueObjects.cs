using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObjects : MonoBehaviour
{

    public Dialogue[] dialObj = new Dialogue[100];
    public int index = 0;
    //public int howManyPlaying = 0;

    public void AddDialogue(Dialogue dialogue)
    {
        dialObj[index] = dialogue;
        index++;
    }
}
