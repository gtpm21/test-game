using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Class handling item pickup and counting the different kinds of pickups/loot
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
    private int treePieces = 61;
    public GameObject floatingText;

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
            if(greenPieces % treePieces == 0)
            {
                greenTreesCollected++;
                ShowFloatingText();
            }
            previousGreenPieces = greenPieces;
        }
        greenTreesText.text = greenTreesCollected.ToString();

        if (previousPinkPieces != pinkPieces && pinkPieces != 0)
        {
            if (pinkPieces % treePieces == 0)
            {
                pinkTreesCollected++;
                ShowFloatingText();
            }
            previousPinkPieces = pinkPieces;
        }
        pinkTreesText.text = pinkTreesCollected.ToString();

        if (previousCyanPieces != cyanPieces && cyanPieces != 0)
        {
            if (cyanPieces % treePieces == 0)
            {
                cyanTreesCollected++;
                ShowFloatingText();
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

    void ShowFloatingText()
    {
        Instantiate(floatingText, transform.position, Quaternion.identity);
    }
}
