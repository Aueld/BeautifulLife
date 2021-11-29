using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class LobbyMenu : PlayerData
{
    private Image img;
    private Text text;

    private void Start()
    {
        img = GameObject.Find("ShowText").GetComponent<Image>();
        img.color = new Color(0, 0, 0, 0);

        text = GameObject.Find("ShText").GetComponent<Text>();
        text.color = new Color(255, 255, 255, 0);
    }

    public void OnClickStart()
    {
        ReSetPara();

        SceneManager.LoadScene("Main");
    }

    public void OnClickUnButton()
    {
        StartCoroutine(Fade());
    }

    public void ReSetPara()
    {
        CreateXmlJug();

        ReSetXml(LoadXmlName(), "Temp");
        //AssetDatabase.Refresh();
    }

    private IEnumerator Fade()
    {
        StartCoroutine(FIn());
        yield return FIn();
        StartCoroutine(FOut());
    }

    private IEnumerator FIn()
    {
        float alpha = 0f;

        while (alpha < 1f)
        {
            img.color = new Color(0, 0, 0, alpha - 0.3f);
            text.color = new Color(255, 255, 255, alpha);
            yield return MainManager.Instance.waitFrame;
            alpha += 0.05f;
        }
    }

    private IEnumerator FOut()
    {
        float alpha = 1f;

        while (alpha > 0)
        {
            if (alpha < 0.15f)
                alpha = 0f;

            img.color = new Color(0, 0, 0, alpha - 0.3f);
            text.color = new Color(255, 255, 255, alpha);
            yield return MainManager.Instance.waitFrame;
            alpha -= 0.1f;
        }
    }
}
