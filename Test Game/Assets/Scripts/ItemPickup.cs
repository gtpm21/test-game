using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour, IDataPersistence
{
    public Canvas canvas;
    public TextMeshProUGUI greenTreesText;
    public TextMeshProUGUI pinkTreesText;
    public TextMeshProUGUI cyanTreesText;
    private double previousGreenPieces;
    private double previousPinkPieces;
    private double previousCyanPieces;
    public double greenPieces = 0;
    public double pinkPieces = 0;
    public double cyanPieces = 0;
    public double greenTreesCollected;
    public double pinkTreesCollected;
    public double cyanTreesCollected;

    // Start is called before the first frame update
    void Start()
    {
        previousGreenPieces = greenPieces;
        previousPinkPieces = pinkPieces;
        previousCyanPieces = cyanPieces;
    }

    // Update is called once per frame
    void Update()
    {
        if (pinkTreesCollected > 0)
        {
            canvas.transform.GetChild(3).gameObject.SetActive(true);
        }
        
        if (cyanTreesCollected > 0)
        {
            canvas.transform.GetChild(4).gameObject.SetActive(true);
        }

        if (previousGreenPieces != greenPieces && greenPieces != 0)
        {
            if(greenPieces % 20 == 0)
            {
                greenTreesCollected++;
            }
            previousGreenPieces = greenPieces;
        }
        greenTreesText.text = greenTreesCollected.ToString();

        if (previousPinkPieces != pinkPieces && pinkPieces != 0)
        {
            if (pinkPieces % 20 == 0)
            {
                pinkTreesCollected++;
            }
            previousPinkPieces = pinkPieces;
        }
        pinkTreesText.text = pinkTreesCollected.ToString();

        if (previousCyanPieces != cyanPieces && cyanPieces != 0)
        {
            if (cyanPieces % 20 == 0)
            {
                cyanTreesCollected++;
            }
            previousCyanPieces = cyanPieces;
        }
        cyanTreesText.text = cyanTreesCollected.ToString();
    }

    public void LoadData(GameData data)
    {
        this.greenTreesCollected = data.greenTreesCollected;
        this.pinkTreesCollected = data.pinkTreesCollected;
        this.cyanTreesCollected = data.cyanTreesCollected;
    }

    public void SaveData(GameData data)
    {
        data.greenTreesCollected = this.greenTreesCollected;
        data.pinkTreesCollected = this.pinkTreesCollected;
        data.cyanTreesCollected = this.cyanTreesCollected;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "pickup_green")
        {
            greenPieces++;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "pickup_pink")
        {
            pinkPieces++;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "pickup_cyan")
        {
            cyanPieces++;
            Destroy(col.gameObject);
        }
    }
}
