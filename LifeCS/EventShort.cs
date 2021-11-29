using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventShort : MonoBehaviour
{
    public Sprite[] endingScens;

    private Vector3 vPos;
    private Text text;
    private Text endText;
    private Image ending;
    private Image back;
    private Color color;
    private Color black;

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
        endText = GameObject.Find("endingText").GetComponent<Text>();
        ending = GameObject.Find("ending").GetComponent<Image>();
        back = GameObject.FindGameObjectWithTag("img").GetComponent<Image>();

        color = ending.color;
        black = new Color(0, 0, 0, 0);

        color.a = 0f;
        ending.color = color;
        endText.color = black;
        vPos = ending.transform.position;

        if (back.raycastTarget)
            back.raycastTarget = false;
    }

    public void EventShortcut(string str, int i)
    {
        transform.localPosition = new Vector3(1040, 100, 0);
        StartCoroutine(EventMove(str, i));
    }

    private IEnumerator EventMove(string str, int i)
    {
        text.text = str;
        
        iTween.MoveAdd(gameObject, iTween.Hash("x", -1040f, "easeType", "easeInOutCirc", "", ""));

        yield return new WaitForSeconds(1.5f);
        
        iTween.MoveAdd(gameObject, iTween.Hash("x", -1040f, "easeType", "easeInOutCirc", "", "", "delay", 1.2f));

        if (i == 1)
        {
            MainManager.Instance.timetime = 0f;

            // endindex 0 1 2 3
            // endPoint 0 1

            // 0 * 2 + 0 = 0
            // 0 * 2 + 1 = 1
            // 1 * 2 + 0 = 2
            // 1 * 2 + 1 = 3
            // 2 * 2 + 0 = 4
            // 2 * 2 + 1 = 5
            // 3 * 2 + 0 = 6
            // 3 * 2 + 1 = 7

            back.raycastTarget = true;
            ending.sprite = endingScens[(MainManager.Instance.endIndex * 2) + (MainManager.Instance.endPoint / 50)];
            EndText();

            StartCoroutine(FadeBack());
        }
    }

    private IEnumerator FadeBack()
    {
        float fade = 0f;
        Color co = new Color(255, 255, 255, 0);
        while(fade < 1f)
        {
            fade += 0.1f;

            co.a = fade;

            back.color = co;

            yield return MainManager.Instance.waitFrame;
        }

        yield return new WaitForSeconds(1f);

        fade = 0f;

        while (fade < 1f)
        {
            fade += 0.05f;

            color.a = fade;
            black.a = fade;

            ending.color = color;
            endText.color = black;

            vPos.y += fade;

            ending.transform.position = vPos;

            yield return MainManager.Instance.waitFrame;
        }

        yield return new WaitForSeconds(10f);

        fade = 1f;
        while (fade > 0)
        {
            fade -= 0.05f;

            if (fade < 0.1f)
                fade = 0;

            color.a = fade;
            black.a = fade;

            ending.color = color;
            endText.color = black;

            yield return MainManager.Instance.waitFrame;
        }

        MainManager.Instance.gameOver = false;

        SceneManager.LoadScene("Lobby");
    }

    private void EndText()
    {
        if (MainManager.Instance.HighStat <= 20)
            endText.text = "실패...";

        Roll(20, 49, 90);
        Roll(50, 74, 50);
        Roll(75, 89, 10);
        Roll(90, 99, 1);

        if (MainManager.Instance.HighStat > 99)
            endText.text = "성공..!";

        if (endText.text.Equals("Temp"))
            endText.text = "실패..?";
    }

    private void Roll(int min, int max, int random)
    {
        int rand = Random.Range(1, 100);

        if (MainManager.Instance.HighStat > min && MainManager.Instance.HighStat < max && rand > random)
            endText.text = "성공..!";
        else if (MainManager.Instance.HighStat > min && MainManager.Instance.HighStat < max && rand <= random)
            endText.text = "실패...";
    }
}
