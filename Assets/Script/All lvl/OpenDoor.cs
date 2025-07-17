using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator _anim; 
    [SerializeField] private bool smenaOsy = false;

    

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>(); //Инициализация аниматора
    }

    //Триггер на вхождение игрока
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            IsOpenDoor();
        }

    }

    //Триггер на выход игрока 
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            IsCloseDoor();
        }
    }

    //Метод для открытия двери
    public void IsOpenDoor()
    {
        if (!smenaOsy)
            _anim.SetBool("isOpenDoor", true);
        else
            _anim.SetBool("isOpenDoor1", true);
    }
    //Метод для закрытия двери
    public void IsCloseDoor()
    {
        if (!smenaOsy)
            _anim.SetBool("isOpenDoor", false);
        else
            _anim.SetBool("isOpenDoor1", false);
    }
}
