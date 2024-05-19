using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Animator startAnim;
   

    public void OnTriggerEnter(Collider other)
    {
        startAnim.SetBool("startOpen", true);
        CursorMenager.instance.cursorWork = true;
    }

    public void OnTriggerExit(Collider other)
    {
        startAnim.SetBool("startOpen", false);
        DialogueManager.instance.EndDialogue();
        CursorMenager.instance.cursorWork = false;
    }
}
