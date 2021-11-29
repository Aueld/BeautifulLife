using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerName : PlayerData
{
    public InputField inputField;
    public Text text;

    public bool check = false;

    private Button button;
    
    private void Start()
    {
        inputField = GameObject.FindGameObjectWithTag("star").GetComponent<InputField>();
        inputField.gameObject.SetActive(false);

        button = GameObject.Find("Ok").GetComponent<Button>();
        button.gameObject.SetActive(false);

        text = GameObject.FindWithTag("block").GetComponent<Text>();

        CreateXmlJug();

        if (LoadXmlName() != "Temp")
            text.text = LoadXmlName();

    }

    public void OnClickName()
    {
        if (!check)
        {
            check = true;
            inputField.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }
        else if (check)
        {

            check = false;
            text.text = inputField.text;
            //Debug.Log(text.text.Length);
            if(text.text.Length < 1)
                text.text = "Rav";

            SaveOverlapXml(text.text, "Temp", LoadXmlStatus());

            //AssetDatabase.Refresh();

            //Object[] GetSprites(string fileName)
            //{
            //    Object[] sprites = Resources.LoadAll(fileName);
            //    return sprites;
            //}

            inputField.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
        }
    }
}
