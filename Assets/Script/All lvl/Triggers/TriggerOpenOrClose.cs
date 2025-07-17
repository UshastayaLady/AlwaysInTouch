using UnityEngine;

public class TriggerOpenOrClose : MonoBehaviour
{
    [SerializeField] private GameObject openObject;
    [SerializeField] private bool onlyOpen = false;
    [SerializeField] private bool onlyClose = false;
    [SerializeField] private bool onceOpenAndClose = false;
    [SerializeField] private bool onceOpenOrClose = false;
    [SerializeField] private bool isInteracting = false;
    [SerializeField] private bool dontButton = false;
    [SerializeField] private KeyCode interactKey = KeyCode.E; // ������� ��� ��������������

    // ����� ���������� ��������� �������
    private void OnTriggerStay()
    {
        if ((Input.GetKeyDown(interactKey) || dontButton) && isInteracting)
        {
            Interact(); // �������� ����� ��������������, ���� ������� ���������
            isInteracting = false;
            return;
        }
        
        if (Input.GetKeyDown(interactKey) && !dontButton && !isInteracting)
        {
            NotInteract(); // �������� ����� ��������������, ���� ������� ���������
            isInteracting = true;
            return;
        }

    }
    private void Interact()
    {
        if (!onlyClose)
        {
            openObject.SetActive(true);
            if (onceOpenOrClose)
            {                
                isInteracting = false;
                this.gameObject.SetActive(false);
            }
        }        
    }

    private void NotInteract()
    {
        if (!onlyOpen)
        {
            openObject.SetActive(false);
            if (onceOpenOrClose || onceOpenAndClose)
            {
                this.gameObject.SetActive(false);                
            }
        }        
    }

    // ������ ��� ��������� ����� � ������ �� ��������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isInteracting) NotInteract();
            isInteracting = false;            
        }
    }
}