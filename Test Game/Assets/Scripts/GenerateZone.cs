using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handling the generation of new zones based on player progression
public class GenerateZone : MonoBehaviour, IDataPersistence
{
    public GameObject zone;
    public GameObject[] prefab;
    public GameObject holder;
    public int numberOfTrees = 150;
    public int zPos;
    public int zonesGenerated;
    private float generationLimitWidth = 9;
    private float generationLimitLenght = 50;
    private int zoneLenght = 100;
    public bool generatedStartingTrees;


    private void OnTriggerEnter(Collider other)
    {
        zPos = holder.GetComponent<GameManager>().zPos;
        zonesGenerated = holder.GetComponent<GameManager>().zonesGenerated;

        if (other.gameObject.tag == "player")
        {
            GameObject newZone = Instantiate(zone, new Vector3(0, 0, zPos), Quaternion.identity);
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, zoneLenght);


            if (zPos == 100) 
            {
                for (int i = 0; i <= numberOfTrees; i++) 
                {
                    var position = new Vector3(Random.Range(-generationLimitWidth, generationLimitWidth), 0, Random.Range(zPos - generationLimitLenght, zPos + generationLimitLenght));
                    GameObject tree = Instantiate(prefab[1], position, Quaternion.identity, newZone.transform);
                    tree.GetComponent<TreeID>().id = System.Guid.NewGuid().ToString();                }
            }
            else if (zPos >100)
            {
                for (int i = 0; i <= numberOfTrees; i++)
                {
                    var position = new Vector3(Random.Range(-generationLimitWidth, generationLimitWidth), 0, Random.Range(zPos - generationLimitLenght, zPos + generationLimitLenght));
                    GameObject tree = Instantiate(prefab[2], position, Quaternion.identity, newZone.transform);
                    tree.GetComponent<TreeID>().id = System.Guid.NewGuid().ToString();
                }
            }
            holder.GetComponent<GameManager>().zonesGenerated++;
            holder.GetComponent<GameManager>().zPos += 100;
        }
    }

    public void LoadData(GameData data)
    {
        if (data.generatedStartingTrees == false)
        {
            for (int i = 0; i <= numberOfTrees; i++)
            {
                var position = new Vector3(Random.Range(-generationLimitWidth, generationLimitWidth), 0, Random.Range(zPos - 130, zPos - generationLimitLenght));
                GameObject tree = Instantiate(prefab[0], position, Quaternion.identity);
                tree.GetComponent<TreeID>().id = System.Guid.NewGuid().ToString();
            }
        }
    }

    public void SaveData(GameData data)
    {
        data.generatedStartingTrees = true;
    }
}
