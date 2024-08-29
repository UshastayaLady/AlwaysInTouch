using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private bool smenaOsy = false;

    private void Awake()
    {

        _anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (!smenaOsy) 
                _anim.SetBool("isOpenDoor", true);
            else
                _anim.SetBool("isOpenDoor1", true);
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (!smenaOsy)
                _anim.SetBool("isOpenDoor", false);
            else
                _anim.SetBool("isOpenDoor1", false);            
        }
    }
}
