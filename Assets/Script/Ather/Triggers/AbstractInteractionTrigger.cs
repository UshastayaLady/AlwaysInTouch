using UnityEngine;

public abstract class AbstractInteractionTrigger : MonoBehaviour
{
    protected bool isInRange = false;
    protected bool isOpenOne = false;
    protected bool isCloseOne = false;
    public KeyCode interactKey = KeyCode.E; // Клавиша для взаимодействия
    public GameObject interactionTarget; // Объект, с которым нужно взаимодействовать

    // Методы для обработки входа и выхода из триггера
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

    // Метод для проверки направления взгляда игрока
    protected virtual bool IsLookingAtObject()
    {
        if (!isInRange) return false;

        //// Находим игрока по тегу
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

    // Абстрактные методы для выполнения взаимодействия
    public abstract void Interact();
    public abstract void NotInteract();

    // Метод обновления состояния объекта
    protected virtual void Update()
    {
        if (IsLookingAtObject())
        {
            if (isOpenOne)
            {
                Interact(); // Вызываем метод взаимодействия, если условие выполнено
                isOpenOne = false;
                isCloseOne = true;
                return;
            }
            if (isCloseOne)
            {
                NotInteract(); // Вызываем метод взаимодействия, если условие выполнено
                isCloseOne = false;
                isOpenOne = true;
                return;
            }
        }
    }
}
