using UnityEngine;

public abstract class AbstractInteractionTrigger : MonoBehaviour
{
    protected bool isInRange = false;
    protected bool isInteracting = false;
    public bool dontButton = false;
    public KeyCode interactKey = KeyCode.E; // Клавиша для взаимодействия

    // Методы для обработки входа и выхода из триггера
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

    // Метод для проверки направления взгляда игрока
    protected virtual bool IsTargetObject()
    {
        if (!isInRange) return false;
        if (Input.GetKeyDown(interactKey) || dontButton)
        {
            return true;
        }
        return false;
    }

    // Абстрактные методы для выполнения взаимодействия
    public abstract void Interact();
    public abstract void NotInteract();

    // Метод обновления состояния объекта
    protected virtual void Update()
    {
        if (IsTargetObject())
        {
            if (isInteracting)
            {
                Interact(); // Вызываем метод взаимодействия, если условие выполнено
                isInteracting = false;
                return;
            }
            if (!isInteracting & !dontButton)
            {
                NotInteract(); // Вызываем метод взаимодействия, если условие выполнено
                isInteracting = true;
                return;
            }
        }
        else if (!IsTargetObject() & dontButton)
        {
            NotInteract(); // Вызываем метод взаимодействия, если условие выполнено                
            isInteracting = true;
            return;
        }
    }
}
