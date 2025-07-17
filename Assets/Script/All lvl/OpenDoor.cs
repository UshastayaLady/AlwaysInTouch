using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator _anim; 
    [SerializeField] private bool smenaOsy = false;

    

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>(); //������������� ���������
    }

    //������� �� ��������� ������
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            IsOpenDoor();
        }

    }

    //������� �� ����� ������ 
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            IsCloseDoor();
        }
    }

    //����� ��� �������� �����
    public void IsOpenDoor()
    {
        if (!smenaOsy)
            _anim.SetBool("isOpenDoor", true);
        else
            _anim.SetBool("isOpenDoor1", true);
    }
    //����� ��� �������� �����
    public void IsCloseDoor()
    {
        if (!smenaOsy)
            _anim.SetBool("isOpenDoor", false);
        else
            _anim.SetBool("isOpenDoor1", false);
    }
}
