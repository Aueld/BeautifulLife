using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStatus : PlayerData
{
    private Text text;

    private bool dont = true;

    protected bool check = false;

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("block").GetComponent<Text>();

        if (LoadXmlName() != "Temp")
            text.text = LoadXmlName();

        transform.localScale = new Vector3(-2, 2, 2);
    }

    public void OnClickStatus()
    {
        if (dont)
        {
            if (!check)
            {
                check = true;
                StartCoroutine(Move(4));
            }
            else if (check)
            {
                check = false;
                StartCoroutine(Move(-4));
            }
        }
    }

    private IEnumerator Move(float x)
    {
        dont = false;
        iTween.ScaleAdd(gameObject, iTween.Hash("x", x, "easeType", "easeOutBounce", "", ""));
        yield return new WaitForSeconds(1f);

        dont = true;
    }
}
