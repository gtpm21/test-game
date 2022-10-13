using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface with the methods that our saveable objects need to implement
public interface IDataPersistence 
{
    void LoadData(GameData data);

    void SaveData(GameData data);
}
