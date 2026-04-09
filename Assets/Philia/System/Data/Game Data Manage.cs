using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Threading.Tasks;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ProBuilder;
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

    private void Start()
    {
        var async = Addressables.InitializeAsync();
        async.Completed += (op) =>
        {
            Addressables.Release(async);
        };
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

    public void CreateCardResource(string resourceName, Transform createPos)
    {
        try
        {
            Addressables.LoadAssetAsync<GameObject>("Philia/Reource/Battle UX/" + resourceName).Completed += (op) =>
            {
                if (op.Status != AsyncOperationStatus.Succeeded)
                {
                    return;
                }

                Instantiate(op.Result, createPos);
            };
        }
        catch {
            Debug.LogError("Create Card Resource void Load Fall. . .");
        }
    }

    /// <summary>
    /// [EN]
    /// Since the production method is 'InstantiateAsync' internally, please call 'ReleaseInstanceResource' as the release call.
    /// 
    /// [KR]
    /// 제작 방식이 내부에서 'InstantiateAsync' 이기 때문에 릴리즈 호출문으로는 'ReleaseInstanceResource' 호출 하십시오.
    /// </summary>
    /// <param name="createPos"></param>
    /// <returns></returns>
    public async Task<AsyncOperationHandle<GameObject>> CreateCardSlot(Transform createPos)
    {
        try
        {
            string cardPrefabName = "Card Slot.prefab";

            var handle = Addressables.InstantiateAsync(AddressableResourceRink.Battle_UX + cardPrefabName, createPos);
            await handle.Task;

            if (handle.Status != AsyncOperationStatus.Succeeded)
                return default;

            return handle;
        }
        catch
        {
            Debug.LogError("Create Card Slot void Load Fall. . .");
        }

        return default;
    }
    
    public async Task<AsyncOperationHandle<Sprite>> LoadResourceDataSprite(string key)
    {
        var handle = Addressables.LoadAssetAsync<Sprite>(key);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            
        }

        return handle;
    }

    public void ReleaseInstanceResource<T>(AsyncOperationHandle<T> sprite)
    {
        Addressables.ReleaseInstance(sprite);
    }

    public void ReleaseResource<T>(AsyncOperationHandle<T> sprite)
    {
        Addressables.Release(sprite);
    }
}

[System.Serializable]
public class ParentsFunction<T>
{
    public T[] values;
}

public class AddressableResourceRink
{
    public const string Battle_UX = "Philia/Reource/Battle UX/";
}