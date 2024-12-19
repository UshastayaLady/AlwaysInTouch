using UnityEngine;

public class NextSceneTrigger : NextSceneButton
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           GoToNextScene(sceneName);
        }
    }
}
