using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class of data we want to store

[System.Serializable]
public class GameData 
{
    public double coinsCoefficient;
    public int coinsMagnitude;
    public Vector3 startingPosition = new Vector3(2, 0, -40.5f);
    public Vector3 playerPosition;
    public double greenTreesCollected;
    public double pinkTreesCollected;
    public double cyanTreesCollected;
    public int zonesGenerated;
    public int zPos;
    public int damage;
    public int damageLvl;
    public double upgradeCost;

    public bool generatedStartingTrees;
    public SerializableDictionary<string, bool> dicIsChopped;//lmao
    public SerializableDictionary<string, float> dicXPos;
    public SerializableDictionary<string, float> dicYPos;
    public SerializableDictionary<string, float> dicZPos;
     


    public GameData()
    {
        this.coinsCoefficient = 0;
        this.coinsMagnitude = 0;
        this.playerPosition = startingPosition;
        this.greenTreesCollected = 0;
        this.pinkTreesCollected = 0;
        this.cyanTreesCollected = 0;
        this.zonesGenerated = 0;
        this.zPos = 100;
        this.damage = 50;
        this.damageLvl = 1;
        this.upgradeCost = 10;

        this.generatedStartingTrees = false;
        dicIsChopped = new SerializableDictionary<string, bool>();
        dicXPos = new SerializableDictionary<string, float>();
        dicYPos = new SerializableDictionary<string, float>();
        dicZPos = new SerializableDictionary<string, float>();
    }
}
