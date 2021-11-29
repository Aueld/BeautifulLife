using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NameSetOk : MonoBehaviour
{
    private PlayerName pn;

    void Start()
    {
        pn = GameObject.Find("NameSet").GetComponent<PlayerName>();
    }

    public void OnClickOk()
    {
        if (pn.check)
        {
            pn.check = false;
            pn.text.text = pn.inputField.text;

            if (pn.text.text.Length < 1)
                pn.text.text = "Rav";

            pn.SaveOverlapXml(pn.text.text, "Temp", pn.LoadXmlStatus());

            //Resources.LoadAll("Character.xml");

            //AssetDatabase.Refresh();

            pn.inputField.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
