using UnityEngine;

public class TriggerFreezCamera : AbstractInteractionTrigger
{
    [SerializeField] private Camera cameraPlayer;
    [SerializeField] private Camera cameraInteract;

    public override void Interact()
    {
        if (cameraPlayer != null && cameraInteract != null)
        {
            cameraPlayer.enabled = false;
            cameraInteract.enabled = true;
        }
    }

    public override void NotInteract()
    {
        if (cameraPlayer != null && cameraInteract != null)
        {
            cameraPlayer.enabled = true;
            cameraInteract.enabled = false;
        }
    }

   
}
