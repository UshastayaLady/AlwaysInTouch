using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimation : MonoBehaviour
{
    [SerializeField] private Animator startAnim;
    [SerializeField] private DialogueManager dm;

    private CursorMenager cursorMenager;

    private void Start()
    {
        cursorMenager = FindObjectOfType<CursorMenager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        startAnim.SetBool("startOpen", true);
        cursorMenager.cursorWork = true;
    }

    public void OnTriggerExit(Collider other)
    {
        startAnim.SetBool("startOpen", false);
        dm.EndDialogue();
        cursorMenager.cursorWork = false;
    }
}
