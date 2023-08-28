using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField]
    private int exp;
    [SerializeField]
    private int gold;

    public int EXP { get { return exp; } set { exp = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
}
