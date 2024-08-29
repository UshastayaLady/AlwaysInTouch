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
        dialogueClosed = false;
        FPS.setFreeze(true);
    }    

    //Closing the dialog box
   public void EndDialogue()
    {
        boxAnim.SetBool("boxOpen", false);
        InstantiateDialogue.instance.CloseDialogue();
        dialogueClosed = true;
        FPS.setFreeze(false);
    }
}
