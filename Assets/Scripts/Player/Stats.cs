using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Stats
{
    public int hp;
    public int DMG;
    public float speed;

    public Stats(int hp, int dmg, float speed)
    {
        this.hp = hp;
        this.DMG = dmg;
        this.speed = speed;
    }
}
