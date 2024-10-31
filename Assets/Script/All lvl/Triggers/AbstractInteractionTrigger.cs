using UnityEngine;

public abstract class AbstractInteractionTrigger : MonoBehaviour
{
    protected bool isInRange = false;
    protected bool isInteracting = false;
    public bool dontButton = false;
    public KeyCode interactKey = KeyCode.E; // ������� ��� ��������������

    // ������ ��� ��������� ����� � ������ �� ��������
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteracting = true;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            if (!isInteracting)
            {
                NotInteract();
            }
            isInteracting = false;
        }
    }

    // ����� ��� �������� ����������� ������� ������
    protected virtual bool IsTargetObject()
    {
        if (!isInRange) return false;
        if (Input.GetKeyDown(interactKey) || dontButton)
        {
            return true;
        }
        return false;
    }

    // ����������� ������ ��� ���������� ��������������
    public abstract void Interact();
    public abstract void NotInteract();

    // ����� ���������� ��������� �������
    protected virtual void Update()
    {
        if (IsTargetObject())
        {
            if (isInteracting)
            {
                Interact(); // �������� ����� ��������������, ���� ������� ���������
                isInteracting = false;
                return;
            }
            if (!isInteracting & !dontButton)
            {
                NotInteract(); // �������� ����� ��������������, ���� ������� ���������
                isInteracting = true;
                return;
            }
        }
        else if (!IsTargetObject() & dontButton)
        {
            NotInteract(); // �������� ����� ��������������, ���� ������� ���������                
            isInteracting = true;
            return;
        }
    }
}
