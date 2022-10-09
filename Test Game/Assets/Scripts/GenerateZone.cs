using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateZone : MonoBehaviour
{
    public GameObject zone;
    public GameObject[] prefab;
    public GameObject holder;
    public int numberOfTrees = 150;
    public int zPos;
    public int zonesGenerated;

    // Start is called before the first frame update
    void Start()
    {

        zPos = holder.GetComponent<DistanceZones>().zPos;
        zonesGenerated = holder.GetComponent<DistanceZones>().zonesGenerated;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            GameObject newZone = Instantiate(zone, new Vector3(0, 0, zPos), Quaternion.identity);

            if (zPos == 100) 
            {
                for (int i = 0; i <= numberOfTrees; i++) 
                {
                    var position = new Vector3(Random.Range(-9f, 9f), 0, Random.Range(zPos - 50, zPos + 50));
                    GameObject tree = Instantiate(prefab[0], position, Quaternion.identity, newZone.transform);
                    tree.GetComponent<TreeID>().id = System.Guid.NewGuid().ToString();
                }
            }
            else if (zPos >100)
            {
                for (int i = 0; i <= numberOfTrees; i++)
                {
                    var position = new Vector3(Random.Range(-9f, 9f), 0, Random.Range(zPos - 50, zPos + 50));
                    GameObject tree = Instantiate(prefab[1], position, Quaternion.identity, newZone.transform);
                    tree.GetComponent<TreeID>().id = System.Guid.NewGuid().ToString();
                }
            }
            holder.GetComponent<DistanceZones>().zonesGenerated++;
            holder.GetComponent<DistanceZones>().zPos += 100;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}