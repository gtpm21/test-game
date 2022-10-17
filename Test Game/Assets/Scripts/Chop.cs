using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class holding player stats.
public class Chop : MonoBehaviour, IDataPersistence
{
    public int damage;
    public double upgradeCost;
    public int damageLvl;

    public void LoadData(GameData data)
    {
        this.damage = data.damage;
        this.upgradeCost = data.upgradeCost;
        this.damageLvl = data.damageLvl;
    }

    public void SaveData(GameData data)
    {
        data.damage = this.damage;
        data.upgradeCost = this.upgradeCost;
        data.damageLvl = this.damageLvl;
    }
}
