using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class StatData : IDataLoader<int, Stat>
{
    public List<Stat> stats = new List<Stat>();

    public Dictionary<int, Stat> LoadData()
    {
        Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
        foreach (Stat stat in stats)
        {
            dict.Add(stat.level, stat);
        }

        return dict;
    }
}

public interface IDataLoader<Key, Value>
{
    public Dictionary<Key, Value> LoadData();
}

public class DataManager
{
    public Dictionary<int, Stat> PlayerStats = new Dictionary<int, Stat>();

    public void Init()
    {
        PlayerStats = LoadJson<StatData, int, Stat>("PlayerStat").LoadData();
    }

    private T LoadJson<T, Key, Value>(string path) where T: IDataLoader<Key, Value>
    {
        TextAsset asset = GameManager.Resource.Load<TextAsset>($"Data/{path}");
        T JsonData = JsonUtility.FromJson<T>(asset.text);

        return JsonData;
    }
}
