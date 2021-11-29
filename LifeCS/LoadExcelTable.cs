using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadExcelTable : MonoBehaviour
{
    private List<Dictionary<string, object>> data_Stage;

    protected List<Vector3> objPos;
    protected List<Vector3> vList;
    //protected List<int> list;

    protected int stage;
    protected int timer = 0;
    protected int index = 0;

    private void Awake()
    {
        data_Stage = CSVReader.Read("RunStageTable");
        //list = new List<int>();
        objPos = new List<Vector3>();
    }

    //private void OnEnable()
    //{
    //     //< column, row >

    //    //for (int i = 0; i < data_Stage.Count; i++)
    //    //{
    //    //    if (data_Stage[i]["STAGE"].ToString().Equals("1"))
    //    //    {
    //    //        //list.Add(int.Parse(data_Stage[i]["ID"].ToString()));
    //    //        objPos.Add(new Vector3(float.Parse(data_Stage[i]["X"].ToString()), float.Parse(data_Stage[i]["Y"].ToString()), float.Parse(data_Stage[i]["Z"].ToString())));
    //    //    }
    //    //}
    //    //foreach (var v in objPos)
    //    //{
    //    //    Debug.Log(v);
    //    //}

    //}

    protected List<Vector3> GetXYZ(string id)
    {
        if (data_Stage == null)
            data_Stage = CSVReader.Read("RunStageTable");

        List<Vector3> vList = new List<Vector3>();

        for (int i = 0; i < data_Stage.Count; i++)
        {
            if (/*data_Stage[i]["STAGE"].ToString().Equals("1") && */data_Stage[i]["ID"].ToString().Equals(id))
            {
                vList.Add(new Vector3(float.Parse(data_Stage[i]["X"].ToString()), float.Parse(data_Stage[i]["Y"].ToString()), float.Parse(data_Stage[i]["Z"].ToString())));
            }
        }
        return vList;
    }

    protected List<int> GetTime(int id)
    {
        if (data_Stage == null)
            data_Stage = CSVReader.Read("RunStageTable");

        List<int> time = new List<int>();

        for (int i = 0; i < data_Stage.Count; i++)
        {
            if (data_Stage[i]["ID"].ToString().Equals(id.ToString()))
            {
                time.Add(int.Parse(data_Stage[i]["TIME"].ToString()));
            }
        }

        return time;
    }
}
