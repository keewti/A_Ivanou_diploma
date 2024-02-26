using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemiesSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _hp;
    [SerializeField] private int _dmg;
    [SerializeField] private float _speed;

    public string Name
    { get { return _name; } }
    public int HP
    { get { return _hp; } set { } }
    public int DMG
    { get { return _dmg; } }
    public float Speed
    { get { return _speed; } }
    public void UpdateHealth(int dmg)
    {
        _hp -= dmg;
    }
}
