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
    public Dictionary<int, Data.PlayerStat> playerStats = new Dictionary<int, Data.PlayerStat>();

    public void Init()
    {
        playerStats = LoadJson<Data.PlayerStats, int, Data.PlayerStat>("PlayerStats").LoadData();
    }

    private T LoadJson<T, Key, Value>(string path) where T: IDataLoader<Key, Value>
    {
        TextAsset asset = GameManager.Resource.Load<TextAsset>($"Data/{path}");
        T data = JsonUtility.FromJson<T>(asset.text);

        return data;
    }
}
