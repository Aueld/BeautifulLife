using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventManager : PlayerData
{
    public bool check = false;

    private EventShort eventShot;

    private bool endCheck = false;
    private float timer = 0;

    void Start()
    {
        CreateXmlJug();
        eventShot = GetComponent<EventShort>();
        timer = 0f;

        StartCoroutine(Updater());
    }

    private IEnumerator Updater()
    {
        while (true)
        {
            timer += 0.08f;

            if (timer > 5 && !check)
            {
                check = true;
                endCheck = false;
                eventShot.EventShortcut("Hello World!", 0);
            }

            if (timer > 50 && MainManager.Instance.gameOver && !endCheck)
            {
                endCheck = true;

                SaveOverlapXml(LoadXmlName(), "Temp", MainManager.Instance.status);
                //AssetDatabase.Refresh();
                eventShot.EventShortcut("END", 1);
            }

            yield return MainManager.Instance.waitFrame;
        }
    }
}
