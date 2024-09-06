using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{  
    [SerializeField] private Animator startAnim;
    [SerializeField] private GameObject startOknoDia;
    [SerializeField] private TextAsset[] ta;
    [SerializeField] private int currentTa = 0;

    [SerializeField] private GameObject GameObjectSetActiv;

    public void OnTriggerStay(Collider other)
    {
        if (InstantiateDialogue.instance.dialogueEnded == true)
        {
            if (InstantiateDialogue.instance.objectSetActiv)
                if (GameObjectSetActiv != null)
                    GameObjectSetActiv.SetActive(!GameObjectSetActiv.activeSelf);

            if (currentTa < ta.Length - 1)
            {
               
                currentTa++;
                InstantiateDialogue.instance.dialogueEnded = false;
            }
            else
            {                
                CursorManager.instance.cursorWork = false;                
                Destroy(this.gameObject);
            }
        }
        InstantiateDialogue.instance.ta = ta[currentTa];
    }

    public void OnTriggerEnter(Collider other)
    {
        startOknoDia.SetActive(true);
        CursorManager.instance.cursorWork = true;
        InstantiateDialogue.instance.dialogueEnded = false;
        startAnim.SetBool("startOpen", true);             
    }

    public void OnTriggerExit(Collider other)
    {
        startOknoDia.SetActive(false);
        startAnim.SetBool("startOpen", false);
        DialogueManager.instance.EndDialogue();
        CursorManager.instance.cursorWork = false;
        InstantiateDialogue.instance.ta = null;
    }
}
