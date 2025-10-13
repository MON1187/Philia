using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices.WindowsRuntime;


public class Test : MonoBehaviour
{
    string modelData_Player_path = "ModeData_Player";
    string modelData_Enemy_path = "ModelData_Enemy";

    string text = ".Text";

    DataTest data;
    DataTest[] _dataArray = new DataTest[3];

    List<DataTest> _dataList = new List<DataTest>();

    public void Awake()
    {
        data = new DataTest();

        //_data = new DataTest[3];

        //_dataList[0] = DataTest(10001, 5, 1, 2);
        //_dataList[1] = DataTest(10002, 4, 5, 2);
        //_dataList[2] = DataTest(10003, 5, 3, 3);

        _dataList.Add(DataTest(10001, 5, 1, 2));
        _dataList.Add(DataTest(10002, 4, 2, 2));
        _dataList.Add(DataTest(10003, 6, 1, 1));

        GameDataManage.Instance.DataUpdateJsonFileArray(_dataList, modelData_Player_path + text);
        data = DataTest(11001, 7, 3, 1);
        GameDataManage.Instance.DataUpdateJsonFile(data, modelData_Enemy_path + text);
    }

    private DataTest DataTest(int id, int hp, int breakHp, int playMaxPoint)
    {
        DataTest data = new DataTest();
        data.id = id;
        data.hp = hp;
        data.breakHp = breakHp;
        data.playMaxPoint = playMaxPoint;

        return data;
    }
}

[Serializable]
public class DataTest {
    public int id;
    public int hp;
    public int breakHp;
    public int playMaxPoint;
}
