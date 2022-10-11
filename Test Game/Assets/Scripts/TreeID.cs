using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeID : MonoBehaviour, IDataPersistence
{
    [SerializeField] private bool isChopped = false;
    [SerializeField] private string id;
    [SerializeField] private int treeHealth = 100;
    [SerializeField] private GameObject fractured;
    

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void Start()
    {
        //id = System.Guid.NewGuid().ToString();
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
                //fractured.GetComponent<Explosion>().Explode();
                Destroy(gameObject);
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
