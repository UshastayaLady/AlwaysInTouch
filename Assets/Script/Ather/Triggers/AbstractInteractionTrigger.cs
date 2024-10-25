using UnityEngine;

public abstract class AbstractInteractionTrigger : MonoBehaviour
{
    protected bool isInRange = false;
    protected bool isOpenOne = false;
    protected bool isCloseOne = false;
    public KeyCode interactKey = KeyCode.E; // ������� ��� ��������������
    public GameObject interactionTarget; // ������, � ������� ����� �����������������

    // ������ ��� ��������� ����� � ������ �� ��������
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            isOpenOne = true;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            if (!isOpenOne & isCloseOne)
            {
                NotInteract();
            }
            isOpenOne = false;
            isCloseOne = false;
        }
    }

    // ����� ��� �������� ����������� ������� ������
    protected virtual bool IsLookingAtObject()
    {
        if (!isInRange) return false;

        //// ������� ������ �� ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Ray ray = new Ray(player.transform.position, player.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == interactionTarget && Input.GetKeyDown(interactKey))
            {
                return true;
            }
        }

        return false;
    }

    // ����������� ������ ��� ���������� ��������������
    public abstract void Interact();
    public abstract void NotInteract();

    // ����� ���������� ��������� �������
    protected virtual void Update()
    {
        if (IsLookingAtObject())
        {
            if (isOpenOne)
            {
                Interact(); // �������� ����� ��������������, ���� ������� ���������
                isOpenOne = false;
                isCloseOne = true;
                return;
            }
            if (isCloseOne)
            {
                NotInteract(); // �������� ����� ��������������, ���� ������� ���������
                isCloseOne = false;
                isOpenOne = true;
                return;
            }
        }
    }
}
