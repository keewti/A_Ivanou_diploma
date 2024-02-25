using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Stats PlayerStats = new Stats(100, 5, 0, 1f);
    private GameObject _dmgZone;
    private Animator _animator;
    private float _curSpeed;
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
    public void StopAttack()
    {
        _animator.SetBool("isAttacking", false);
        PlayerStats.speed = _curSpeed;
        _dmgZone.SetActive(false);
    }
}
