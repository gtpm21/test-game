using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class TreeID : MonoBehaviour, IDataPersistence
{
    [SerializeField] public bool isChopped = false;
    [SerializeField] public string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void Start()
    {
        GameAnalytics.Initialize();
    }

    public void LoadData(GameData data)
    {
        data.treesChopped.TryGetValue(id, out isChopped);
        if (isChopped)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.treesChopped.ContainsKey(id))
        {
            data.treesChopped.Remove(id);
        }
        data.treesChopped.Add(id, isChopped);
    }

}
