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
    public SerializableDictionary<string, bool> treesChoppedDic;



    public SerializableDictionary<string, Vector3> treesPositionDic;
    public int zonesGenerated;
    public int zPos;


    public GameData()
    {
        this.coins = new AlphabeticNotation(0d);
        this.playerPosition = startingPosition;
        this.greenTreesCollected = 0;
        this.pinkTreesCollected = 0;
        this.cyanTreesCollected = 0;
        treesChoppedDic = new SerializableDictionary<string, bool>();



        treesPositionDic = new SerializableDictionary<string, Vector3>();
        this.zonesGenerated = 0;
        this.zPos = 100;

    }
}
