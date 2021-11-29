//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Xml;

//public class XMLData : MonoBehaviour
//{
//    private string path = @"./Assets/Resources/Character.xml";

//    public void CreateXml(string fName)
//    {
//        //Xml 파일이 없을때 생성

//        XmlDocument xmlDoc = new XmlDocument();

//        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

//        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "CharacterInfo", string.Empty);
//        xmlDoc.AppendChild(root);

//        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "Character", string.Empty);
//        root.AppendChild(child);

//        XmlElement name = xmlDoc.CreateElement("Name");
//        name.InnerText = fName;
//        child.AppendChild(name);

//        XmlElement age = xmlDoc.CreateElement("Age");
//        age.InnerText = "1";
//        child.AppendChild(age);

//        XmlElement status = xmlDoc.CreateElement("Status");
//        status.InnerText = "20,20,20,20,20,50,";
//        child.AppendChild(status);

//        xmlDoc.Save(path);
//        //xmlDoc.Save(@"./Assets/Resources/Character.xml");
//    }

//    public string LoadXmlStatus()
//    {
//        //Xml 파일 특정값 불러오기

//        CreateXmlJug();

//        TextAsset textAsset = (TextAsset)Resources.Load("Character");
//        //Debug.Log(textAsset);
//        XmlDocument xmlDoc = new XmlDocument();
//        xmlDoc.LoadXml(textAsset.text);

//        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");

//        string str = "";
//        foreach (XmlNode node in nodes)
//        {
//            //Debug.Log("Name :: " + node.SelectSingleNode("Name").InnerText);
//            //Debug.Log("Age :: " + node.SelectSingleNode("Age").InnerText);
//            //Debug.Log("Status :: " + node.SelectSingleNode("Status").InnerText);
//            str = node.SelectSingleNode("Status").InnerText;
//        }
//        return str;
//    }

//    public string LoadXmlName()
//    {
//        //Xml 파일 특정값 불러오기

//        TextAsset textAsset = (TextAsset)Resources.Load("Character");
//        //Debug.Log(textAsset);
//        XmlDocument xmlDoc = new XmlDocument();
//        xmlDoc.LoadXml(textAsset.text);

//        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");

//        string str = "";
//        foreach (XmlNode node in nodes)
//        {
//            //Debug.Log("Name :: " + node.SelectSingleNode("Name").InnerText);
//            //Debug.Log("Age :: " + node.SelectSingleNode("Age").InnerText);
//            //Debug.Log("Status :: " + node.SelectSingleNode("Status").InnerText);
//            str = node.SelectSingleNode("Name").InnerText;
//        }
//        return str;
//    }

//    public void SaveOverlapXml(string name, string age, string status)
//    {
//        //Xml 파일 저장

//        TextAsset textAsset = (TextAsset)Resources.Load("Character");
//        XmlDocument xmlDoc = new XmlDocument();
//        xmlDoc.LoadXml(textAsset.text);

//        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");
//        XmlNode character = nodes[0];

//        character.SelectSingleNode("Name").InnerText = name;
//        character.SelectSingleNode("Age").InnerText = age;
//        character.SelectSingleNode("Status").InnerText = status;//"20,20,20,20,20,0,0";

//        xmlDoc.Save(path);

//        //리소스 파일 즉시 저장하고 싶으면

//        //using UnityEditor;
//        //AssetDatabase.Refresh();

//        //추가
//    }

//    public void ReSetXml(string name, string age)
//    {
//        //Xml 파일 저장

//        TextAsset textAsset = (TextAsset)Resources.Load("Character");
//        XmlDocument xmlDoc = new XmlDocument();
//        xmlDoc.LoadXml(textAsset.text);

//        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");
//        XmlNode character = nodes[0];

//        character.SelectSingleNode("Name").InnerText = name;
//        character.SelectSingleNode("Age").InnerText = age;
//        character.SelectSingleNode("Status").InnerText = "20,20,20,20,20,50";

//        //xmlDoc.Save("Character.xml");

//        xmlDoc.Save(path);

//        //Resources.LoadAll(@"./Assets/Resources/Character.xml");

//        //리소스 파일 즉시 저장하고 싶으면
//        //Resources.Load("Character.xml");
//        //using UnityEditor;
//        //AssetDatabase.Refresh();

//        //추가
//    }

//    protected void CreateXmlJug()
//    {
//        // Xml 파일이 존재하는지 확인

//        //string _Filestr = "./Assets/Resources/Character.xml";

//        string _Filestr = path;
//        System.IO.FileInfo fi = new System.IO.FileInfo(_Filestr);
//        if (!fi.Exists)
//        {
//            CreateXml("Temp");
//        }
//    }
//}
