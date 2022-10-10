using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LargeNumbers;

[System.Serializable]
public class GameData 
{
    public AlphabeticNotation coins;
    public Vector3 startingPosition = new Vector3(2, 0, -40.5f);
    public Vector3 playerPosition;
    public double greenTreesCollected;
    public double pinkTreesCollected;
    public double cyanTreesCollected;
    public SerializableDictionary<string, bool> treesChopped;

    public GameData()
    {
        this.coins = new AlphabeticNotation(0d);
        this.playerPosition = startingPosition;
        this.greenTreesCollected = 0;
        this.pinkTreesCollected = 0;
        this.cyanTreesCollected = 0;
        treesChopped = new SerializableDictionary<string, bool>();
    }
}
