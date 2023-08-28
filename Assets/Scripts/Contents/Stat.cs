using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    private int level;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int max_hp;
    [SerializeField]
    private int attack;
    [SerializeField]
    private int defense;
    [SerializeField]
    private float moveSpeed;

    public int Level { get { return level; } set { level = value; } }
    public int HP { get { return hp; } set { hp = value; } }
    public int MaxHP { get { return max_hp; } set { max_hp = value; } }
    public int Attack { get { return attack; } set { attack = value; } }
    public int Defense { get { return defense; } set { defense = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
}
