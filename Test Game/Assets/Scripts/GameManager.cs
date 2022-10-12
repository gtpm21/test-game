using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public int zPos;
    private int tempzPos;
    private int zoneLenght = 100;
    public int zonesGenerated;
    public GameObject zone;
    public GameObject wallTrigger;

    public bool isChopped;
    public string id;
    public Vector3 treePos;
    public GameObject[] prefab;

    private void Start()
    {
        GameAnalytics.Initialize();
    }

    public void LoadData(GameData data)
    {
        this.zonesGenerated = data.zonesGenerated;
        this.zPos = data.zPos;

        if(zonesGenerated > 0) 
        {
            LoadZones();
        }



        foreach (var item in data.treesPositionDic)
        {           
            if(item.Value.z < 150 && item.Value.z > 50)
            {
                GameObject tree = Instantiate(prefab[1], item.Value, Quaternion.identity);
                tree.GetComponent<TreeID>().id = item.Key;
            }
            else if (item.Value.z > 150)
            {
                GameObject tree = Instantiate(prefab[2], item.Value, Quaternion.identity);
                tree.GetComponent<TreeID>().id = item.Key;

            }
        }
    }

    public void SaveData(GameData data)
    {
        data.zonesGenerated = this.zonesGenerated;
        data.zPos = this.zPos;
    }

    void LoadZones()
    {
        tempzPos = zPos - (zonesGenerated * zoneLenght);
        for (int i = 0; i < zonesGenerated; i++) 
        { 
            GameObject newZone = Instantiate(zone, new Vector3(0, 0, tempzPos), Quaternion.identity);
            tempzPos += zoneLenght;
            wallTrigger.transform.position = wallTrigger.transform.position + new Vector3(0, 0, zoneLenght);
        }
    }
}
