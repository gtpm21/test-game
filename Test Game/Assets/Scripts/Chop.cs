using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class holding player stats.
public class Chop : MonoBehaviour, IDataPersistence
{
    public int damage;
    public int damageLvl;

    public void LoadData(GameData data)
    {
        this.damage = data.damage;
        this.damageLvl = data.damageLvl;
    }

    public void SaveData(GameData data)
    {
        data.damage = this.damage;
        data.damageLvl = this.damageLvl;
    }
}
