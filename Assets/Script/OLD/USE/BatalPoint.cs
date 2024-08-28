using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatalPoint : MonoBehaviour
{
    private Text name;
    private Text fename;
    private Text xp;
    private Text lvl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        name.text = FIO.a;
        fename.text = FIO.b;
        xp.text = "Опыт: " + health.xp;
        lvl.text = "Уровень: " + health.lvl;

    }
}
