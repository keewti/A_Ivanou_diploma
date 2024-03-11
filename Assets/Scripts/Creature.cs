using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    protected abstract int Dmg { get; }
    protected int Hp { get; }
    protected abstract Animator Animator { get; }

    public virtual void TakeDMG(int DMG)
    {
        DeathCheck();
    }
    public virtual void DeathCheck()
    {

    }
}
