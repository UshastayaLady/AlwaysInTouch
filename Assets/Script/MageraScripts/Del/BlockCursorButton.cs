using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockCursorButton : MonoBehaviour
{  
    private void Start()
    {
        Button blockCursor = GetComponent<Button>();

        if (blockCursor != null)
        {
            blockCursor.onClick.AddListener(BlockCursor);
        }
        else
        {
            Debug.LogError("Exit button not found!");
        }
    }


    // �����, ���������� ��� ������� ������
    private void BlockCursor()
    {
        CursorMenager.instance.cursorWork = false;
    }
}
