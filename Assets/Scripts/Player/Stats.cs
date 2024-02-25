using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Stats
{
    public int hp;
    public int attackDMG;
    public int contactDMG;
    public float speed;

    public Stats(int hp, int attackDMG, int contactDMG, float speed)
    {
        this.hp = hp;
        this.attackDMG = attackDMG;
        this.contactDMG = contactDMG;
        this.speed = speed;
    }
}
