using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemiesSO _enemy;
    [SerializeField] private Player _player; 
    private void Start()
    {
        _player = FindObjectOfType<Player>(); // TODO: make enemies find player without it
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.transform.CompareTag("Player"))
        {
            _player.TakeDMG(_enemy.DMG);
        }
    }
}
