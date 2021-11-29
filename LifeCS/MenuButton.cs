using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public bool hr = false;

    private Image image;
    private Image menu;
    private OpenStatus open;

    private bool check = false;

    private void Start()
    {
        image = GameObject.FindGameObjectWithTag("img").GetComponent<Image>();
        menu = GameObject.FindGameObjectWithTag("menu").GetComponent<Image>();

        image.color = new Color(0, 0, 0, 0.0f);
        menu.transform.localPosition = new Vector3(3000, 0, 0);

        open = GameObject.Find("OpenStatus").GetComponent<OpenStatus>();
    }

    public void OnclickPause()
    {
        if (hr && MainManager.Instance.stageChange)
        {
            MainManager.Instance.Stagechange();

            open.OnClickStatus();
        }

        if (!MainManager.Instance.playerHit)
        {
            if (!check)
            {
                check = true;
                image.color = new Color(0, 0, 0, 0.5f);
                menu.transform.localPosition = new Vector3(0, 0, 0);
                MainManager.Instance.PauseGame();
            }
            else if (check)
            {
                check = false;
                image.color = new Color(0, 0, 0, 0.0f);
                menu.transform.localPosition = new Vector3(3000, 0, 0);
                MainManager.Instance.ContinueGame();
            }
        }
    }
}
