using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggTestBegin : MonoBehaviour
{
    public GameObject TestBeginButton, TestGeneral ;
    GameObject Player;
    bool enter;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Player);
    }
    public void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E))
        {
            TestBeginButton.SetActive(false);
            TestGeneral.SetActive(true);
            Player.GetComponent<FPSCONROL>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TestBeginButton.SetActive(true);
            enter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TestBeginButton.SetActive(false);
            enter = false;
        }
    }
}
