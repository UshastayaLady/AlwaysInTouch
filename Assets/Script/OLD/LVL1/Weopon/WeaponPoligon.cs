using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPoligon : MonoBehaviour
{

    public GameObject Welcome;   
    
    public void Contine()
    {
        Welcome.SetActive(false);
      
        Cursor.lockState = CursorLockMode.Locked;
       
        GameObject man;
        man = GameObject.FindGameObjectWithTag("Player");
        man.GetComponent<FirstPersonController>().enabled = true;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            

            Welcome.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            GameObject man;
            man = GameObject.FindGameObjectWithTag("Player");
            man.GetComponent<FirstPersonController>().enabled = false;
        }
    }

}
