using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeID : MonoBehaviour, IDataPersistence
{
    [SerializeField] public bool isChopped;
    [SerializeField] public string id;
    [SerializeField] public Vector3 treePos;
    [SerializeField] private int treeHealth = 100;
    [SerializeField] private GameObject fractured;


    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void Start()
    {

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
                gameObject.SetActive(false);
            }
        }
    }

    public void LoadData(GameData data)
    {

    }

    public void SaveData(GameData data)
    {
        //if (isChopped)
        //{
        //    data.treesChoppedDic[id] = true;
        //}
        data.treesPositionDic[id] = gameObject.transform.position;

        if (data.treesChoppedDic.ContainsKey(id))
        {
            data.treesChoppedDic.Remove(id);
        }
        data.treesChoppedDic.Add(id, isChopped);

        /*if (data.treesPositionDic.ContainsKey(id))
        {
            data.treesPositionDic.Remove(id);
        }
        data.treesPositionDic.Add(id, gameObject.transform.position);*/
    }
}
