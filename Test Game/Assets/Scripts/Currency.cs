using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LargeNumbers;
using TMPro;

//Class handling shop functions and player currency
public class Currency : MonoBehaviour, IDataPersistence
{
    public TextMeshProUGUI AlphabeticNotationText;
    public AlphabeticNotation currency = new AlphabeticNotation();
    public GameObject player;
    public int greenTreeValue = 1;
    public int pinkTreeValue = 2;
    public int cyanTreeValue = 3;

    void Update()
    {
        AlphabeticNotationText.text = currency.ToString();
    }

    public void LoadData(GameData data)
    {
        this.currency.coefficient = data.coinsCoefficient;
        this.currency.magnitude = data.coinsMagnitude;
    }

    public void SaveData(GameData data)
    {
        data.coinsCoefficient = this.currency.coefficient;
        data.coinsMagnitude = this.currency.magnitude;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            currency = currency + (player.GetComponent<ItemPickup>().greenTreesCollected * greenTreeValue);
            currency = currency + (player.GetComponent<ItemPickup>().pinkTreesCollected * pinkTreeValue);
            currency = currency + (player.GetComponent<ItemPickup>().cyanTreesCollected * cyanTreeValue);

            player.GetComponent<ItemPickup>().greenPieces = 0;
            player.GetComponent<ItemPickup>().pinkPieces = 0;
            player.GetComponent<ItemPickup>().cyanPieces = 0;

            player.GetComponent<ItemPickup>().greenTreesCollected = 0;
            player.GetComponent<ItemPickup>().pinkTreesCollected = 0;
            player.GetComponent<ItemPickup>().cyanTreesCollected = 0;
        }
    }
}
