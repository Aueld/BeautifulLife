using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUp : MonoBehaviour
{
    private Image image;
    private Text text;
    private Color color;

    void Start()
    {
        image = GameObject.FindGameObjectWithTag("stat").GetComponent<Image>();
        text = GameObject.FindGameObjectWithTag("statText").GetComponent<Text>();

        image.color = new Color(0, 0, 0, 0);
        text.color = new Color(0, 0, 0, 0);
        color = new Color(255, 255, 255, 0);
    }

    public void StatusUp(string str)
    {
        text.text = str;
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float fade = 0f;

        while (fade < 1)
        {
            fade += 0.3f;

            color.a = fade;

            image.color = color;
            text.color = color;

            yield return MainManager.Instance.waitFrame;
        }

        while (fade > 0f)
        {
            fade -= 0.2f;

            if (fade < 0.25f)
                fade = 0f;

            color.a = fade;

            image.color = color;
            text.color = color;

            yield return MainManager.Instance.waitFrame;
        }
    }
}
