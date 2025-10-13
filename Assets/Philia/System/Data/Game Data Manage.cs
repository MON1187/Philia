using UnityEngine;
using System.Collections.Generic;
using System.IO;
public class GameDataManage : MonoBehaviour
{
    public static GameDataManage Instance;

    string path;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void DataUpdateJsonFile<T>(T data, string _fileName)
    {
        try
        {
            string json = JsonUtility.ToJson(data, true);

            if (json.Equals("{}"))
            {
                Debug.Log("json Null");
            }

            path = Application.persistentDataPath + "/Resource" + "/" + _fileName;
            File.WriteAllText(path, json);

            //Debug.Log($"Save Completed : {path}");
        }
        catch
        {
            Debug.Log("No");
        }
    }

    public void DataUpdateJsonFileArray<T>(T[] data, string _fileName)
    {
        ParentsFunction<T> warrper = new ParentsFunction<T>() { values = data };
        DataUpdateJsonFile(warrper, _fileName);
    }

    public void DataUpdateJsonFileArray<T>(List<T> data, string _fileName)
    {
        T[] values = new T[data.Count];
        for (int i = 0; i < data.Count; i++)
        {
            values[i] = data[i];
        }

        DataUpdateJsonFileArray(values, _fileName);
    }
}

[System.Serializable]
public class ParentsFunction<T>
{
    public T[] values;
}
