using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    public void TriggerDialog()
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
