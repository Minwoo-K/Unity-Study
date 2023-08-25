using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region PlayerStat
[Serializable]
public class PlayerStat
{
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class PlayerStats : IDataLoader<int, PlayerStat>
{
    public List<PlayerStat> Stats = new List<PlayerStat>();

    public Dictionary<int, PlayerStat> LoadData()
    {
        Dictionary<int, PlayerStat> statData = new Dictionary<int, PlayerStat>();

        foreach (PlayerStat stat in Stats)
        {
            statData.Add(stat.level, stat);
        }

        return statData;
    }
}

#endregion

