using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneButton : MonoBehaviour
{
    [SerializeField] protected string sceneName;
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => GoToNextScene(sceneName));
        }
    }


    // �����, ���������� ��� ������� ������
    public void GoToNextScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}