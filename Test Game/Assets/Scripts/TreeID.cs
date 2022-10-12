using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeID : MonoBehaviour, IDataPersistence
{
    [SerializeField] public bool isChopped = false;
    [SerializeField] public string id;
    [SerializeField] private int treeHealth = 100;
    [SerializeField] private GameObject fractured;
    [SerializeField] private GameObject prefab;
    [SerializeField] public Vector3 treePos;


    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void Start()
    {
        treePos = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("axe"))
        {
            treeHealth -= other.GetComponent<Chop>().damage;

            if(treeHealth <= 0)
            {
                isChopped = true;
                Instantiate(fractured, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    public void LoadData(GameData data)
    {
        data.treesChoppedDic.TryGetValue(id, out isChopped);
        if (isChopped)
        {
            gameObject.SetActive(false);
        }

        data.treesPositionDic.TryGetValue(id, out treePos);
        if (!isChopped && gameObject.activeInHierarchy == false) { 
            Instantiate(prefab, treePos, Quaternion.identity);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.treesChoppedDic.ContainsKey(id))
        {
            data.treesChoppedDic.Remove(id);
        }
        data.treesChoppedDic.Add(id, isChopped);

        if (data.treesPositionDic.ContainsKey(id))
        {
            data.treesPositionDic.Remove(id);
        }
        data.treesPositionDic.Add(id, treePos);
    }

}
