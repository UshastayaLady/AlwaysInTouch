using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private FirstPersonController FPS;

    [SerializeField] private Animator boxAnim;
    [SerializeField] private Animator startAnim;

    [SerializeField] public bool dialogueClosed = true;

    public static DialogueManager instance = null;

    public void Start()
    {
        if (instance == null)
        { instance = this; }

        FPS = FindObjectOfType<FirstPersonController>();
    }        

    //Starting a dialogue
    public void StartDialogue()
    {
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);
        CursorManager.instance.cursorWork = true;
        dialogueClosed = false;
        FPS.setFreeze(true);
    }    

    //Closing the dialog box
   public void EndDialogue()
    {
        InstantiateDialogue.instance.CloseDialogue();
        boxAnim.SetBool("boxOpen", false);
        CursorManager.instance.cursorWork = false;
        dialogueClosed = true;
        FPS.setFreeze(false);
    }
}
