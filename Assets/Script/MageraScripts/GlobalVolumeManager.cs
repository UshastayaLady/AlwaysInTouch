using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVolumeManager : MonoBehaviour
{
    public static GlobalVolumeManager instance; // Ссылка на единственный экземпляр этого класса
    public float globalVolume = 1.0f; // Глобальная громкость по умолчанию

    void Awake()
    {
        // Проверяем, существует ли уже экземпляр класса
        if (instance == null)
        {
            // Если нет, то делаем этот экземпляр текущим
            instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожаем этот объект при загрузке новой сцены
        }
        else
        {
            // Если уже существует экземпляр класса, уничтожаем этот объект
            Destroy(gameObject);
        }
    }
}
