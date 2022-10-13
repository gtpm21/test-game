using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handling tree behavior
public class TreeID : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int treeHealth = 100;
    [SerializeField] private GameObject fractured;
    [SerializeField] public bool isChopped;
    [SerializeField] public string id;
    [SerializeField] public float xPos;
    [SerializeField] public float yPos;
    [SerializeField] public float zPos;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void Start()
    {
        //DataPersistenceManager.instance.UpdateDataPersistenceObjects(this);
        //DataPersistenceManager.instance.dataPersistenceObjects.Add(this);
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
        data.dicIsChopped.TryGetValue(id, out isChopped);
        if (isChopped)
        {
            gameObject.SetActive(false);
        }
        if(data.dicXPos.ContainsKey(id) && data.dicYPos.ContainsKey(id) && data.dicZPos.ContainsKey(id))
        {
            data.dicXPos.TryGetValue(id, out xPos);
            data.dicYPos.TryGetValue(id, out yPos);
            data.dicZPos.TryGetValue(id, out zPos);
            transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.dicIsChopped.ContainsKey(id))
        {
            data.dicIsChopped.Remove(id);
        }
        data.dicIsChopped.Add(id, isChopped);

        if (data.dicXPos.ContainsKey(id))
        {
            data.dicXPos.Remove(id);
        }
        data.dicXPos.Add(id, transform.position.x);

        if (data.dicYPos.ContainsKey(id))
        {
            data.dicYPos.Remove(id);
        }
        data.dicYPos.Add(id, transform.position.y);

        if (data.dicZPos.ContainsKey(id))
        {
            data.dicZPos.Remove(id);
        }
        data.dicZPos.Add(id, transform.position.z);
    }   
}
