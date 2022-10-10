using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeID : MonoBehaviour, IDataPersistence
{
    [SerializeField] public bool isChopped = false;
    [SerializeField] public string id;
    [SerializeField] public int treeHealth = 100;
    

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("axe"))
        {
            treeHealth -= other.GetComponent<Chop>().damage;

            if(treeHealth <= 0)
            {

            isChopped = true;
            }
        }
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
