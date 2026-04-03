using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameDataManage : MonoBehaviour
{
    public static GameDataManage Inst;

    string path;
    void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
            DontDestroyOnLoad(Inst);
        }
        else
        {
            Destroy(Inst);
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

    public async void LoadResourceDataSprite(string key, UnityEngine.UI.Image target)
    {
        var handle = Addressables.LoadAssetAsync<Sprite>(key);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            target.sprite = handle.Result;
        }

        Addressables.Release(handle);
    }
}

[System.Serializable]
public class ParentsFunction<T>
{
    public T[] values;
}
