using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemiesSO _enemy;
    [SerializeField] private Player _player;
    private Animator _animator;
    private int _curHP;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>(); // TODO: make enemies find player without it
        //var a = _enemy.HP;
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
        _enemy.UpdateHealth(dmg);
        Debug.Log(_enemy.HP);
        DeathCheck();
    }
    private void DeathCheck() // todo: make elder class for enemies and player to do stuff like this
    {
        if (_enemy.HP <= 0) 
        {
            _enemy.HP = 0;
            _animator.SetBool("isDead", true);
        }
        StartCoroutine(DeathRoutine(0.65f));
    }
    IEnumerator DeathRoutine(float time)
    {
        _animator.SetBool("isJumping", true);
        float counter = 0;
        while (counter <= time)
        {
            counter += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }

}
