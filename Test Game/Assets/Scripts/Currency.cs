using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LargeNumbers;
using TMPro;

public class Currency : MonoBehaviour, IDataPersistence
{
    public TextMeshProUGUI AlphabeticNotationText;
    public AlphabeticNotation currency = new AlphabeticNotation(0d);
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        AlphabeticNotationText.text = currency.ToString();
    }

    public void LoadData(GameData data)
    {
        this.currency = data.coins;
    }

    public void SaveData(GameData data)
    {
        data.coins = this.currency;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            currency = currency + (player.GetComponent<ItemPickup>().greenTreesCollected * 1);
            currency = currency + (player.GetComponent<ItemPickup>().pinkTreesCollected * 2);
            currency = currency + (player.GetComponent<ItemPickup>().cyanTreesCollected * 3);

            player.GetComponent<ItemPickup>().greenTreesCollected = 0;
            player.GetComponent<ItemPickup>().pinkTreesCollected = 0;
            player.GetComponent<ItemPickup>().cyanTreesCollected = 0;

            player.GetComponent<ItemPickup>().greenPieces = 0;
            player.GetComponent<ItemPickup>().pinkPieces = 0;
            player.GetComponent<ItemPickup>().cyanPieces = 0;

        }
    }
}
