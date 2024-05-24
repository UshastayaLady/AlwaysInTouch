using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private void Awake()
    {

        _anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            _anim.SetBool("isOpenDoor", true);
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            _anim.SetBool("isOpenDoor", false);
        }
    }
}
