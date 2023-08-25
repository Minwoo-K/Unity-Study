using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDataLoader<Key, Value>
{
    public Dictionary<Key, Value> LoadData();
}

public class DataManager
{
    // Data Containers
    public Dictionary<int, Stat> PlayerStats = new Dictionary<int, Stat>();



    // Initialize any required data here in prior to the start of the game
    public void Init()
    {
        PlayerStats = LoadJson<StatData, int, Stat>("PlayerStat").LoadData();
    }

    // Template method to load any Json data into a Data Container
    private T LoadJson<T, Key, Value>(string path) where T: IDataLoader<Key, Value>
    {
        TextAsset asset = GameManager.Resource.Load<TextAsset>($"Data/{path}");
        T JsonData = JsonUtility.FromJson<T>(asset.text);

        return JsonData;
    }
}
