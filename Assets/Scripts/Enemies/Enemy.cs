using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemiesSO _enemy;
    [SerializeField] private Player _player;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>(); // TODO: make enemies find player without it
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _player.TakeDMG(_enemy.DMG);
        }
    }
    public void TakeDMG(int dmg)
    {
        _enemy.HP -= dmg;
        Debug.Log(_enemy.HP);
    }
    private void DeathCheck() // todo: make elder class for enemies and player to do stuff like this
    {
        if (_enemy.HP <= 0) 
        { 
            _enemy.HP = 0;
            _animator.SetBool("isDead", true);
        }
    }
}
