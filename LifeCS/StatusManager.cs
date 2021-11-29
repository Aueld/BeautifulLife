using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    protected int Health { get; set; }
    //protected int Mentality { get; set; }
    //protected int Strong { get; set; }
    protected int Intellect { get; set; }
    //protected int Leadership { get; set; }
    //protected int Elegance { get; set; }
    protected int Charm { get; set; }

    //---------------------------------------
    //protected int Affection { get; set; }
    //protected int Moraluty { get; set; }
    protected int Sensibility { get; set; }
    //protected int Independence { get; set; }
    //protected int Flexibility { get; set; }
    //protected int Sociability { get; set; }
    //protected int Logic { get; set; }
    //protected int Pride { get; set; }
    //protected int Creativity { get; set; }

    //---------------------------------------
    protected int Stress { get; set; }
    protected int HealthStatus { get; set; }
    //protected int Cavity { get; set; }
    //protected int Interest { get; set; }
    //protected int Weight { get; set; }
    //protected int Height { get; set; }
    //protected int Tendency { get; set; }
    //protected int Costume { get; set; }

    /*
     Affection
    morality
    sensibility
    independence
    flexibility
    sociability
    logic
    Pride
    creativity

    stress
    health status
    cavity
    interest

    weight
    key
    tendency
    costume

     */


    //---------------------------------------
    
    protected List<string> HealthStr = new List<string>();
    protected List<string> IntellectStr = new List<string>();
    protected List<string> SensibilityStr = new List<string>();
    protected List<string> CharmStr = new List<string>();

    protected List<string[]> fill = new List<string[]>();

    //---------------------------------------

    protected Text text;
    protected Text statusText;

    protected Text[] statText = new Text[4];
    protected Text[] statFText = new Text[4];
    protected Image[] Bar = new Image[4];

    protected PlayerData pData;
    protected StatUp statUp;

    protected bool check = true;

    protected int[] arr = new int[8];
    protected int[] token = new int[6];

    protected string[] strarr = new string[8];

    protected void SetVelue(int[] arr)
    {
        Health = arr[0];
        Intellect = arr[1];
        Sensibility = arr[2];
        Charm = arr[3];

        Stress = arr[4];
        HealthStatus = arr[5];
    }
}
