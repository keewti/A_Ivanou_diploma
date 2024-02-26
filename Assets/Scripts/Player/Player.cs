using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] public Stats PlayerStats = new Stats(100, 5, 0, 1f);
    private GameObject _dmgZone;
    private Animator _animator;
    private float _curSpeed;
    public static UnityEvent<bool> IsAlive = new();
    private void Start()
    {
        _curSpeed = PlayerStats.speed;
        _dmgZone = transform.GetChild(0).gameObject;
        _dmgZone.SetActive(false);
        _animator = GetComponent<Animator>();
    }
    public void Attack()
    {
        PlayerStats.speed = 0;
        _animator.SetBool("isAttacking", true);
        _dmgZone.SetActive(true);
    }
    private void StopAttack()
    {
        _animator.SetBool("isAttacking", false);
        PlayerStats.speed = _curSpeed;
        _dmgZone.SetActive(false);
    }
    public void TakeDMG(int DMG)
    {
        Debug.Log(PlayerStats.hp);
        PlayerStats.hp -= DMG;
        DeathCheck();
    }
    private void DeathCheck()
    {
        if (PlayerStats.hp <= 0) 
        { 
            PlayerStats.hp = 0;
            Kill();
        }
    }
    private void Kill()
    {
        //todo lose screen
        _animator.SetBool("isDead", true);
        IsAlive.Invoke(false);
    }
}
