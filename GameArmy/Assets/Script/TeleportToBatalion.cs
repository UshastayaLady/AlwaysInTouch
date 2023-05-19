using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToBatalion : MonoBehaviour
{
    public GameObject Marker;

    private void OnTriggerEnter(Collider col)
    {
         if(col.tag == "Player")
         {
            Debug.Log("DFisdfisdjfisdfisdjfisdjf");
            SceneManager.LoadScene(1);
         }
    }
}