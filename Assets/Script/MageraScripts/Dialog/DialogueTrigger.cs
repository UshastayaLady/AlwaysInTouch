using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{  
    [SerializeField] private Animator startAnim;
    [SerializeField] private GameObject startOknoDia;
    [SerializeField] private TextAsset[] ta;
    [SerializeField] private int currentTa = 0;
    
    public void OnTriggerStay(Collider other)
    {
        if (InstantiateDialogue.instance.dialogueEnded == true)
        {
            if (currentTa < ta.Length - 1)
            {
                currentTa++;
                InstantiateDialogue.instance.dialogueEnded = false;
            }
            else
            {                
                CursorMenager.instance.cursorWork = false;
                Destroy(this.gameObject);
            }
        }
        InstantiateDialogue.instance.ta = ta[currentTa];
    }

    public void OnTriggerEnter(Collider other)
    {
        startOknoDia.SetActive(true);
        CursorMenager.instance.cursorWork = true;
        InstantiateDialogue.instance.dialogueEnded = false;
        startAnim.SetBool("startOpen", true);             
    }

    public void OnTriggerExit(Collider other)
    {
        startOknoDia.SetActive(false);
        startAnim.SetBool("startOpen", false);
        DialogueManager.instance.EndDialogue();
        CursorMenager.instance.cursorWork = false;
        InstantiateDialogue.instance.ta = null;
    }
}
