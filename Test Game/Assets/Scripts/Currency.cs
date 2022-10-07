using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LargeNumbers;
using TMPro;

public class Currency : MonoBehaviour
{
    public TextMeshProUGUI AlphabeticNotationText;
    public AlphabeticNotation currency = new AlphabeticNotation(0d);
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            currency = currency + (player.GetComponent<ItemPickup>().greenTreesCollected * 1);
            currency = currency + (player.GetComponent<ItemPickup>().pinkTreesCollected * 2);
            currency = currency + (player.GetComponent<ItemPickup>().cyanTreesCollected * 3);

            AlphabeticNotationText.text = currency.ToString();

            player.GetComponent<ItemPickup>().greenTreesCollected = 0;
            player.GetComponent<ItemPickup>().pinkTreesCollected = 0;
            player.GetComponent<ItemPickup>().cyanTreesCollected = 0;

            player.GetComponent<ItemPickup>().greenPieces = 0;
            player.GetComponent<ItemPickup>().pinkPieces = 0;
            player.GetComponent<ItemPickup>().cyanPieces = 0;

        }
    }
}
