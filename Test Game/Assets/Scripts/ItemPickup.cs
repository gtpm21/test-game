using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    public TextMeshProUGUI greenTreesText;
    public TextMeshProUGUI pinkTreesText;
    public TextMeshProUGUI cyanTreesText;
    private double previousGreenPieces;
    private double previousPinkPieces;
    private double previousCyanPieces;
    public double greenPieces = 0;
    public double pinkPieces = 0;
    public double cyanPieces = 0;
    public double greenTreesCollected = 0;
    public double pinkTreesCollected = 0;
    public double cyanTreesCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        previousGreenPieces = greenPieces;
        previousPinkPieces = pinkPieces;
    }

    // Update is called once per frame
    void Update()
    {
        if (previousGreenPieces != greenPieces)
        {
            if(greenPieces % 20 == 0)
            {
                greenTreesCollected++;
            }
            previousGreenPieces = greenPieces;
        }
        greenTreesText.text = greenTreesCollected.ToString();

        if (previousPinkPieces != pinkPieces)
        {
            if (pinkPieces % 20 == 0)
            {
                pinkTreesCollected++;
            }
            previousPinkPieces = pinkPieces;
        }
        pinkTreesText.text = pinkTreesCollected.ToString();

        if (previousCyanPieces != cyanPieces)
        {
            if (cyanPieces % 20 == 0)
            {
                cyanTreesCollected++;
            }
            previousCyanPieces = cyanPieces;
        }
        cyanTreesText.text = cyanTreesCollected.ToString();
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
