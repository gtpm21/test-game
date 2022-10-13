using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

//class handling the saving and loading of zones and trees. Also used to initialize GameAnalytics.

public class GameManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject zone;
    [SerializeField] private GameObject wallTrigger;
    public int zPos;
    private int tempzPos;
    private int zoneLenght = 100;
    public int zonesGenerated;

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
        //Loading trees
        foreach(var item in data.dicZPos)
        {
            treePos = new Vector3(data.dicXPos[item.Key], data.dicYPos[item.Key], item.Value);

            if(item.Value < 50)
            {
                GameObject tree = Instantiate(prefab[0], treePos, Quaternion.identity);
                tree.GetComponent<TreeID>().id = item.Key;
                tree.GetComponent<TreeID>().isChopped = data.dicIsChopped[item.Key];
                if (tree.GetComponent<TreeID>().isChopped == true)
                {
                    tree.SetActive(false);
                }
            }
            else if (item.Value < 150 && item.Value > 50)
            {
                GameObject tree = Instantiate(prefab[1], treePos, Quaternion.identity);
                tree.GetComponent<TreeID>().id = item.Key;
                tree.GetComponent<TreeID>().isChopped = data.dicIsChopped[item.Key];
                if (tree.GetComponent<TreeID>().isChopped == true)
                {
                    tree.SetActive(false);
                }
            }
            else if (item.Value > 150)
            {
                GameObject tree = Instantiate(prefab[2], treePos, Quaternion.identity);
                tree.GetComponent<TreeID>().id = item.Key;
                tree.GetComponent<TreeID>().isChopped = data.dicIsChopped[item.Key];
                if (tree.GetComponent<TreeID>().isChopped == true)
                {
                    tree.SetActive(false);
                }
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
