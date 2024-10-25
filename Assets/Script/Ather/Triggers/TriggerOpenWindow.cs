using UnityEngine;

public class TriggerOpenWindow : AbstractInteractionTrigger
{
    [SerializeField] private GameObject openObject;
    public override void Interact()
    {
        openObject.SetActive(true);
    }

    public override void NotInteract()
    {
        openObject.SetActive(false);
    }
}
