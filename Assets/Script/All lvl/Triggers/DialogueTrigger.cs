using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{  
    [SerializeField] private Animator startAnim;
    [SerializeField] private GameObject startOknoDia;
    [SerializeField] private TextAsset[] ta;
    [SerializeField] private int currentTa = 0;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    private bool enter = false;

    [System.Serializable]
    public class ObjectSetActiv
    {
        public GameObject GameObjectSetActiv;
        public int dialogueCount;
    }
    [SerializeField] private List<ObjectSetActiv> GameObjectSetActiv;

    private void Update()
    {
        if (enter && Input.GetKeyDown(interactKey))
        {
            DialogueManager.instance.StartDialogue();
            enter = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (InstantiateDialogue.instance.dialogueEnded == true)
        {
            if (InstantiateDialogue.instance.objectSetActiv)
                if (GameObjectSetActiv != null)
                    for (int i = 0; i < GameObjectSetActiv.Count; i++)
                    {
                        if (GameObjectSetActiv[i].dialogueCount == currentTa)
                        {
                            GameObjectSetActiv[i].GameObjectSetActiv.SetActive(!GameObjectSetActiv[i].GameObjectSetActiv.activeSelf);
                        }
                    }

            if (currentTa < ta.Length - 1)
            {              
                currentTa++;
                InstantiateDialogue.instance.dialogueEnded = false;                
            }
            else
            {                
                Destroy(this.gameObject);
            }
        }
        InstantiateDialogue.instance.ta = ta[currentTa];
    }

    public void OnTriggerEnter(Collider other)
    {
        startOknoDia.SetActive(true);
        enter = true;
        InstantiateDialogue.instance.dialogueEnded = false;
        startAnim.SetBool("startOpen", true);             
    }

    public void OnTriggerExit(Collider other)
    {
        startOknoDia.SetActive(false);
        startAnim.SetBool("startOpen", false);
        DialogueManager.instance.EndDialogue();
        enter = false;
        InstantiateDialogue.instance.ta = null;
    }
}
