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
    public int zonesGenerated;
    public int zPos;


    public SerializableDictionary<string, bool> dicIsChopped;//lmao
    public SerializableDictionary<string, float> dicXPos;
    public SerializableDictionary<string, float> dicYPos;
    public SerializableDictionary<string, float> dicZPos;
     


    public GameData()
    {
        this.coins = new AlphabeticNotation(0d);
        this.playerPosition = startingPosition;
        this.greenTreesCollected = 0;
        this.pinkTreesCollected = 0;
        this.cyanTreesCollected = 0;
        this.zonesGenerated = 0;
        this.zPos = 100;


        dicIsChopped = new SerializableDictionary<string, bool>();
        dicXPos = new SerializableDictionary<string, float>();
        dicYPos = new SerializableDictionary<string, float>();
        dicZPos = new SerializableDictionary<string, float>();
    }
}
