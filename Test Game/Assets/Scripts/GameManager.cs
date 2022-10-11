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
